namespace Tender.Storage.Context
{
    /// <summary>
    /// Migration Context Interface
    /// </summary>
    public interface IMigrationService
    {
        /// <summary>
        /// This will start the DB Migration Automatically
        /// </summary>
        void StartMigration();
    }
}
