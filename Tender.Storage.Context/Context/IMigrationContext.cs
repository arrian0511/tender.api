using System;
using System.Collections.Generic;
using System.Text;

namespace Tender.Storage.Context
{
    /// <summary>
    /// Migration Context Interface
    /// </summary>
    public interface IMigrationContext
    {
        /// <summary>
        /// This will start the DB Migration Automatically
        /// </summary>
        void StartMigration();
    }
}
