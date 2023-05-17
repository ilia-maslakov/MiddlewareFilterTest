using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;

namespace Store.DataMigrator
{
    public class Migration
    {
        public int Id { get; set; }
        #pragma warning disable CS8618
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
        #pragma warning restore CS8618
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
        public DbSet<Migration> Migrations { get; set; }

        public const string MigrationsTableName = "__migrations";

        public MigrationContext() {
            Migrations = Set<Migration>();
        }

        public MigrationContext(DbContextOptions<MigrationContext> options) : base(options)
        {
            Migrations = Set<Migration>();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Migration>().ToTable(MigrationsTableName);

        }

        public static Migration GetNewMigration(string reason, int schemaVersion, int nscripts, string version)
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
            catch (Exception)
            {
                //A Sql exception will be thrown if tables already exist. So simply ignore it.
                //var message = e.Message;
            }

        }
    }
}
