using AutoMapper;
using OperationsService.Contracts;
using OperationsService.Contracts.Dtos;
using OperationsService.Contracts.Exceptions;
using OperationsService.Data;
using OperationsService.Validators;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OperationsService
{
    public class OperationsService: IOperationsService
    {
        private readonly OperationsDbContext _operationsDbContext;

        public OperationsService(OperationsDbContext operationsDbContext)
        {
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

        public async Task TransferAsync(TransferRequest transferRequest)
        {
            var validator = new TransferRequestValidator(_operationsDbContext);
            var validateResult = validator.Validate(transferRequest);

            if (!validateResult.IsValid)
                throw new TransferException(validateResult.Errors.Select(a => a.ErrorMessage));

            await Task.CompletedTask;
        }
    }
}
