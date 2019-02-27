using AutoMapper;
using NotificationService.Contracts;
using OperationsService.Contracts;
using OperationsService.Contracts.Dtos;
using OperationsService.Contracts.Exceptions;
using OperationsService.Data;
using OperationsService.Data.Entities;
using OperationsService.Utils;
using OperationsService.Validators;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Threading.Tasks;

namespace OperationsService
{
    public class OperationsService: IOperationsService
    {
        private readonly OperationsDbContext _operationsDbContext;
        private readonly INotificationService _notificationService;

        public OperationsService(OperationsDbContext operationsDbContext, INotificationService notificationService)
        {
            _notificationService = notificationService;
            _operationsDbContext = operationsDbContext;
        }

        public async Task<IList<Bank>> GetBanksAsync()
        {
            var dbBanks = await _operationsDbContext.Banks.ToListAsync();
            var banks = Mapper.Map<IList<Bank>>(dbBanks);
            return banks;
        }

        public async Task<IList<Invoice>> GetSenderInvoicesAsync(Guid bankId)
        {
            var dbInvoices = await _operationsDbContext.Invoices.Where(a => a.BankId == bankId).ToListAsync();
            var invoices = Mapper.Map<IList<Invoice>>(dbInvoices);
            return invoices;
        }

        public async Task<IList<Invoice>> GetRecipientInvoicesAsync(Guid bankId, Guid sendrInvoiceId)
        {
            var dbInvoices = await _operationsDbContext.Invoices.Where(a => a.BankId == bankId && a.Id != sendrInvoiceId).ToListAsync();
            var invoices = Mapper.Map<IList<Invoice>>(dbInvoices);
            return invoices;
        }

        public async Task TransferAsync(TransferRequest transferRequest, Guid requestUserId)
        {
            var notificationService = new NotificationService.NotificationService();

            // Validation
            var validator = new TransferRequestValidator(_operationsDbContext);
            var validateResult = validator.Validate(transferRequest);

            if (!validateResult.IsValid)
                throw new TransferException(validateResult.Errors.Select(a => a.ErrorMessage));

            // Get data for operation
            var recipientInvoice = await _operationsDbContext.Invoices
                .Include(a => a.Bank)
                .Include(a => a.InvoiceType)
                .FirstOrDefaultAsync(a => a.Id == transferRequest.RecipientInvoiceId);

            if (recipientInvoice == null)
                throw new TransferException("Получатель не найден.");

            var senderInvoice = await _operationsDbContext.Invoices
                .Include(a => a.Bank)
                .FirstOrDefaultAsync(a => a.Id == transferRequest.SenderInvoiceId);

            if (senderInvoice == null)
                throw new TransferException("Отправитель не найден.");

            var dbMatrix = await _operationsDbContext.Matrices
                                             .FirstOrDefaultAsync(a => a.SenderTypeId == senderInvoice.InvoiceTypeId
                                                               && a.RecipientTypeId == recipientInvoice.InvoiceTypeId);

            if (dbMatrix == null)
                throw new TransferException("Нет матрицы для расчета комиссии.");

            // Calc interest
            var bankInterested = Helpers.CalcBankInterested(senderInvoice.Bank, senderInvoice, recipientInvoice, transferRequest.Ammount);
            var transferInterested = Helpers.CalcTransferInterested(dbMatrix, transferRequest.Ammount);

            var chargeAmount = transferRequest.Ammount + bankInterested + transferInterested;

            if (senderInvoice.Ammount < chargeAmount)
                throw new TransferException("Недостаточно средств.");

            var notifications = Helpers.CreateNotifications(recipientInvoice.InvoiceType, senderInvoice.Bank);

            // Operation
            senderInvoice.Ammount -= chargeAmount;
            recipientInvoice.Ammount += transferRequest.Ammount;

            var dbTransaction = new DbTransation()
            {
                Ammount = transferRequest.Ammount,
                RecipientInvoiceId = recipientInvoice.Id,
                SenderInvoiceId = senderInvoice.Id,
                TransferDate = DateTime.UtcNow,
                BankInterest = bankInterested,
                TransferInterest = transferInterested,
                TransferUserId = requestUserId,
            };

            using (var transaction = _operationsDbContext.Database.BeginTransaction())
            {
                try
                {
                    _operationsDbContext.Transations.Add(dbTransaction);
                    await _operationsDbContext.SaveChangesAsync();

                    await notificationService.SendAsync(notifications);

                    transaction.Commit();
                }
                catch (DbUpdateConcurrencyException)
                {
                    transaction.Rollback();
                    throw new TransferException("Данные обновились ранее.");
                }
                catch (Exception)
                {
                    transaction.Rollback();
                    throw new TransferException("Произошла системная ошибка.");
                }
            }
        }
    }
}
