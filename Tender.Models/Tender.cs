using Newtonsoft.Json;
using System;

namespace Tender.Models
{
    public class Tender
    {
        [JsonProperty(Order = 1)]
        public Guid Id { get; set; }

        [JsonProperty(Order = 2)]
        public string Requirements { get; set; }

        [JsonProperty(Order = 3)]
        public DateTime? StartDate { get; set; }

        [JsonProperty(Order = 4)]
        public DateTime? EndDate { get; set; }

        [JsonProperty(Order = 5)]
        public string CurrentBid { get; set; }

        [JsonProperty(Order = 6)]
        public string FinalBid { get; set; }

        [JsonProperty(Order = 7)]
        public int BiddersCount { get; set; }

        [JsonProperty(Order = 8)]
        public TenderOwner Owner { get; set; }
    }
}
