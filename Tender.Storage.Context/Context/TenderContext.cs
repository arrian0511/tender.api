using System;
using Microsoft.EntityFrameworkCore;
using Tender.Models;

namespace Tender.Storage.Context
{
    /// <summary>
    /// Tender Context Class
    /// </summary>
    public class TenderContext: DbContext
    {
        public DbSet<TenderTask>    TenderTasks     { get; set; }
        public DbSet<TenderOwner>   TenderOwners    { get; set; }
        public DbSet<Bidder>        Bidders         { get; set; }

        /// <summary>
        /// Constructor
        /// </summary>
        public TenderContext(DbContextOptions<TenderContext> options)
            : base (options)
        {
        }

        /// <summary>
        /// On Model Creation
        /// </summary>
        /// <param name="modelBuilder">[in] Model Builder</param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Set Fluent to TenderTask
            modelBuilder.Entity<TenderTask>().Property(task => task.Id).IsRequired();
            modelBuilder.Entity<TenderTask>().HasMany<Bidder>(task => task.Bidders);

            // Set Fluent to TenderOwners
            modelBuilder.Entity<TenderOwner>().Property(owner => owner.Id).IsRequired();

            // Set Fluent to Bidders
            modelBuilder.Entity<Bidder>().Property(bidder => bidder.Id).IsRequired();
        }
    }
}
