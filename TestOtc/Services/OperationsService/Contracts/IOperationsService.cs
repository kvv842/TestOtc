using OperationsService.Contracts.Dtos;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OperationsService.Contracts
{
    public interface IOperationsService
    {
        Task<IList<Bank>> GetBanksAsync();

        Task<IList<Invoice>> GetSenderInvoicesAsync(Guid bankId);

        Task<IList<Invoice>> GetRecipientInvoicesAsync(Guid bankId, Guid senderInvoiceId);

        Task TransferAsync(TransferRequest transferRequest, Guid requestUserId);
    }
}
