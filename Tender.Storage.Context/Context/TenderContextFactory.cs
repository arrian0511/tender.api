using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.Configuration;
using System;

namespace Tender.Storage.Context
{
    /// <summary>
    /// Tender Context Factory Class
    /// `Note` This class is use to manually or update the database by using
    /// dotnet ef migrations add InitialMigration or update
    /// </summary>
    public class TenderContextFactory : IDbContextFactory<TenderContext>
    {
        /// <summary>
        /// This is the method that gets called by the “dotnet ef database update” command when you deploy your migrations.
        /// It assumes that your appsettings.json file will be near the code and the csproj file.
        /// </summary>
        /// <param name="options">Configuration options</param>
        /// <returns>TenderContext Instance</returns>
        public TenderContext Create(DbContextFactoryOptions options)
        {
            var connectionString = "Server=(localdb)\\mssqllocaldb;Database=TenderDB;Trusted_Connection=True;";

            // Return the whole db context for configuration
            DbContextOptionsBuilder<TenderContext> _opt = new DbContextOptionsBuilder<TenderContext>();
            _opt.UseSqlServer(connectionString);
            return new Context.TenderContext(_opt.Options);
        }
    }
}
