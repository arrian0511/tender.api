using System;
using System.Collections.Generic;
using System.Text;

namespace Tender.Services
{
    public interface IStorageMigrationService
    {
        /// <summary>
        /// Start the migration and seeding
        /// </summary>
        void StartMigration();
    }
}
