using Newtonsoft.Json;
using Tender.Models.Infrastructure;

namespace Tender.Models
{
    /// <summary>
    /// Bidder Class
    /// </summary>
    [JsonObject(MemberSerialization.OptOut)]
    public class Bidder : Entity
    {
        public string Name          { get; set; }
        public string Email         { get; set; }
        public string Credentials   { get; set; }

        /// <summary>
        /// Constructor
        /// </summary>
        public Bidder()
        {
            /// Initialize Member Variables <BR>
        }
    }
}
