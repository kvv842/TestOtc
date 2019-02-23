using Newtonsoft.Json;
using System;

namespace OperationsService.Contracts.Dtos
{
    public class Bank
    {
        [JsonProperty("id")]
        public Guid Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }
    }
}
