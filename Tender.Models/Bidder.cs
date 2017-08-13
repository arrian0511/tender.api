using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Tender.Models
{
    public class Bidder
    {
        [JsonProperty(Order = 1)]
        public Guid Id { get; set; }

        [JsonProperty(Order = 2)]
        public string Name { get; set; }

        [JsonProperty(Order = 3)]
        public string Email { get; set; }

        [JsonProperty(Order = 4)]
        public string Credentials { get; set; }
    }
}
