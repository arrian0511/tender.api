using System;

namespace Tender.Models.Infrastructure
{
    /// <summary>
    /// Entity Interface
    /// </summary>
    public interface IEntity
    {
        Guid Id { get; set; }
    }
}
