using Newtonsoft.Json;
using System;

namespace OperationsService.Contracts.Dtos
{
    public class Invoice
    {
        [JsonProperty("id")]
        public Guid Id { get; set; }

        [JsonProperty("number")]
        public string Number { get; set; }

        [JsonProperty("bank_id")]
        public Guid BankId { get; set; }

        [JsonProperty("invoice_type")]
        public string InvoiceType { get; set; }

        [JsonProperty("ammount")]
        public double Ammount { get; set; }
    }
}
