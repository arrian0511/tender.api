using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace Tender.Storage.Context
{
    public class MigrationContext : IMigrationContext
    {
        private TenderContext _context;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="context"></param>
        public MigrationContext(TenderContext context)
        {
            this._context = context;
        }

        /// <summary>
        /// This will start the DB Migration Automatically and 
        /// check weather the DB is updated or not
        /// </summary>
        public void StartMigration()
        {
            try
            {
                if (this._context.Database.GetPendingMigrations().Any())
                {
                    this._context.Database.Migrate();
                    Debug.WriteLine("Successfully migrated the database.");
                }
                else
                {
                    Debug.WriteLine("Database is up to date.");
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }

        public static void CreateInstance()
        {
            
        }
    }
}
