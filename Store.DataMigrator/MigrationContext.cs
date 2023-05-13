using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;

namespace Store.DataMigrator
{
    public class Migration
    {
        public int Id { get; set; }
        public string Version { get; set; }
        public string Reason { get; set; }
        public string Status { get; set; }
        public string LastRunScript { get; set; }
        public string LastRunResult { get; set; }
        public int ScriptsRun { get; set; }
        public int ScriptsTotal { get; set; }
        public int SchemaVersion { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }

    public enum MigrationStatus
    {
        None,
        Succeeded,
        Failed,
        Running
    }

    public class MigrationContext : DbContext
    {
        #region Tables

        public DbSet<Migration> Migrations { get; set; }

        public const string MigrationsTableName = "__migrations";

        #endregion

        #region Constructors

        public MigrationContext() { }

        public MigrationContext(DbContextOptions<MigrationContext> options) : base(options) { }

        #endregion

        #region Protected methods

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Migration>().ToTable(MigrationsTableName);

        }

        #endregion

        #region Operations

        public Migration GetNewMigration(string reason, int schemaVersion, int nscripts, string version)
        {
            return new Migration()
            {
                Reason = reason,
                Version = version ?? "",
                Status = MigrationStatus.Running.ToString(),
                LastRunScript = "",
                LastRunResult = "",
                ScriptsRun = 0,
                ScriptsTotal = nscripts,
                StartDate = DateTime.UtcNow,
                SchemaVersion = schemaVersion,
            };
        }

        public Migration? GetLatestMigration(int schemaVersion)
        {
            var statuses = new[] { MigrationStatus.Succeeded.ToString(), MigrationStatus.Running.ToString() };

            return Migrations.Where(p => statuses.Contains(p.Status) && p.SchemaVersion == schemaVersion).OrderBy(p => p.Id).LastOrDefault();
        }

        public void EnsureMigrationTable()
        {
            Database.EnsureCreated();

            try
            {
                var databaseCreator = Database.GetService<IDatabaseCreator>() as RelationalDatabaseCreator;

                databaseCreator?.CreateTables();

            }
            catch (Exception e)
            {
                //A Sql exception will be thrown if tables already exist. So simply ignore it.
                var message = e.Message;
            }

        }

        #endregion

    }
}
