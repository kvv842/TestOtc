using System;

namespace OperationsService.Contracts.Dtos
{
    public class TransferRequest
    {
        public Guid SenderInvoiceId { get; set; }

        public Guid RecipientInvoiceId { get; set; }

        public double Ammount { get; set; }
    }
}
