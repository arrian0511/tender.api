using Newtonsoft.Json;
using Tender.Models.Infrastructure;

namespace Tender.Models
{
    /// <summary>
    /// Tender Owner Class
    /// </summary>
    [JsonObject(MemberSerialization.OptOut)]
    public class TenderOwner : Entity
    {
        public string Name          { get; set; }
        public string Email         { get; set; }
        public string Organization  { get; set; }

        /// <summary>
        /// Constructor
        /// </summary>
        public TenderOwner()
        {
            /// Initialize Member Variables <BR>
        }
    }
}
