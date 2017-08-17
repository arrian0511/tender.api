using System;
using System.Collections.Generic;
using System.Text;
using Tender.Storage.Context;

namespace Tender.Services
{
    public class StorageMigrationService : IStorageMigrationService
    {
        private readonly IMigrationService _migrationContext;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="migrationContext">Migration context instance</param>
        public StorageMigrationService(IMigrationService migrationContext)
        {
            this._migrationContext = migrationContext;
        }

        /// <summary>
        /// Start the migration and seeding
        /// </summary>
        public void StartMigration()
        {
            this._migrationContext.StartMigration();
        }
    }
}
