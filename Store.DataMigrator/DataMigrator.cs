using Microsoft.EntityFrameworkCore;

namespace Store.DataMigrator
{
    public static class Migrator
    {
        public static void Migrate<TCTX>(Func<DbContextOptionsBuilder, DbContextOptions> dbOptionConf, Action<TCTX> dbMigrate) where TCTX : DbContext
        {
            // Configure database context and migrate with standard API
            dbMigrate(CreateDbContext<TCTX>(dbOptionConf));
        }

        static TCTX CreateDbContext<TCTX>(Func<DbContextOptionsBuilder, DbContextOptions> dbOptionConf) where TCTX : DbContext
        {
            var optionsBuilder = new DbContextOptionsBuilder<TCTX>();
            var options = dbOptionConf(optionsBuilder);

            if (options == null)
            {
                throw new InvalidOperationException("Failed to create DbContextOptions.");
            }
            else
            {
                var type = typeof(TCTX);
                var instance = Activator.CreateInstance(type, options);
                if (instance is TCTX res)
                {
                    return res;
                }
                else
                {
                    throw new InvalidOperationException("Failed to create DbContextOptions.");
                }
            }
        }
    }
}
