using Newtonsoft.Json;
using System;

namespace Tender.Models.Infrastructure
{
    /// <summary>
    /// Entity Class
    /// </summary>
    public class Entity : IEntity
    {
        [JsonProperty(Order = 1)]
        public virtual Guid Id { get; set; }
    }
}
