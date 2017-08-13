using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.Configuration;

namespace Tender.Storage.Context
{
    /// <summary>
    /// Configuration Factory
    /// </summary>
    public class ConfigureFactory : IDbContextFactory<TenderContext>
    {
        /// <summary>
        /// This is the method that gets called by the “dotnet ef database update” command when you deploy your migrations.
        /// It assumes that your appsettings.json file will be near the code and the csproj file.
        /// </summary>
        /// <param name="options">Configuration options</param>
        /// <returns>TenderContext Instance</returns>
        public TenderContext Create(DbContextFactoryOptions options)
        {
            var connection = @"Server=(localdb)\mssqllocaldb;Database=TenderDB;Trusted_Connection=True;";
            DbContextOptionsBuilder<TenderContext> _opt = new DbContextOptionsBuilder<TenderContext>();
            _opt.UseSqlServer(connection, (act) => act.MigrationsAssembly("Tender.Storage.Context"));
            return new Context.TenderContext(_opt.Options);
        }
    }
}
