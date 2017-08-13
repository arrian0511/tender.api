using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using Tender.Models.Infrastructure;

namespace Tender.Models
{
    /// <summary>
    /// Tender Task Model
    /// </summary>
    [JsonObject(MemberSerialization.OptOut)]
    public class TenderTask : Entity
    {
        public string       Requirements    { get; set; }
        public DateTime?    StartDate       { get; set; }
        public DateTime?    EndDate         { get; set; }
        public string       CurrentBid      { get; set; }
        public string       FinalBid        { get; set; }
        public TenderOwner  Owner           { get; set; }
        public ICollection<Bidder> Bidders  { get; set; }

        /// <summary>
        /// Constructor
        /// </summary>
        public TenderTask()
        {
            /// Initialize Member Variables <BR>
            this.Bidders = new List<Bidder>();
        }

        /// <summary>
        /// Copy the data from the given object
        /// </summary>
        /// <param name="includeId"></param>
        public void Copy(TenderTask tenderTaskObject, bool includeId = true)
        {
            this.Requirements = tenderTaskObject.Requirements;
            this.StartDate = tenderTaskObject.StartDate;
            this.EndDate = tenderTaskObject.EndDate;
            this.CurrentBid = tenderTaskObject.CurrentBid;
            this.FinalBid = tenderTaskObject.FinalBid;
            this.Owner = tenderTaskObject.Owner;
            this.Bidders = tenderTaskObject.Bidders;
            if (includeId) this.Id = tenderTaskObject.Id;
        }
    }
}
