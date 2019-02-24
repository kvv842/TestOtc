using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApp.Models.Operations
{
    public class InvoiceModel
    {
        public Guid Id { get; set; }

        public string Number { get; set; }

        public Guid BankId { get; set; }

        public string InvoiceType { get; set; }

        public double Ammount { get; set; }
    }
}