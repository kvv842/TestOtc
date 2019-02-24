using System;

namespace WebApp.Models.Operations
{
    public class TransferModel
    {
        public Guid SenderInvoiceId { get; set; }

        public Guid RecipientInvoiceId { get; set; }

        public double Ammount { get; set; }
    }
}