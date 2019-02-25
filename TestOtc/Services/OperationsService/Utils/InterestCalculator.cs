using OperationsService.Contracts.Exceptions;
using OperationsService.Data;
using OperationsService.Data.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OperationsService.Utils
{
    /// <summary>
    /// Расчет процентов
    /// </summary>
    public class InterestCalculator
    {
        private readonly OperationsDbContext _operationsDbContext;

        public InterestCalculator(OperationsDbContext operationsDbContext)
        {
            _operationsDbContext = operationsDbContext;
        }

        public async Task<CalcResult> CalcAsync(DbInvoice senderInvoice, DbInvoice recipientInvoice, decimal ammount)
        {
            var transferInterested = await CalcTransferInterestedAsync(senderInvoice, recipientInvoice, ammount);
            var bankInterested = await CalcBankInterestedAsync(senderInvoice, recipientInvoice, ammount);

            return new CalcResult
            {
                TransferInterested = transferInterested,
                BankInterested = bankInterested,
            };
        }

        #region TransferInterested

        private async Task<decimal> CalcTransferInterestedAsync(DbInvoice senderInvoice, DbInvoice recipientInvoice, decimal ammount)
        {
            var dbMatrix = await GetDbMatrixInvoiceTypesAsync(senderInvoice, recipientInvoice);

            var interested = CalcPercent(ammount, dbMatrix.Interest);

            return interested;
        }

        private async Task<DbMatrixInvoiceTypes> GetDbMatrixInvoiceTypesAsync(DbInvoice senderInvoice, DbInvoice recipientInvoice)
        {
            var dbMatrix = await _operationsDbContext.Matrices
                                              .FirstOrDefaultAsync(a => a.SenderTypeId == senderInvoice.InvoiceTypeId
                                                                && a.RecipientTypeId == recipientInvoice.InvoiceTypeId);

            if (dbMatrix == null)
                throw new TransferException("Нет матрицы для расчета комиссии.");

            return dbMatrix;
        }

        #endregion TransferInterested

        #region BankInterested

        private async Task<decimal> CalcBankInterestedAsync(DbInvoice senderInvoice, DbInvoice recipientInvoice, decimal ammount)
        {
            var senderBank = await _operationsDbContext.Banks.FirstAsync(a => a.Id == senderInvoice.BankId);

            var percent = (IsInternalTransfer(senderInvoice, recipientInvoice))
                          ? senderBank.InterestInternalTransfer
                          : senderBank.InterestExternalTransfer;

            return CalcPercent(ammount, percent);
        }

        private bool IsInternalTransfer(DbInvoice senderInvoice, DbInvoice recipientInvoice)
            => senderInvoice.BankId == recipientInvoice.BankId;

        private decimal CalcPercent(decimal ammount, decimal percent)
            => ammount / 100 * percent;

        #endregion BankInterested

        public class CalcResult
        {
            public decimal TransferInterested { get; set; }
            public decimal BankInterested { get; set; }
        }

        
    }
}
