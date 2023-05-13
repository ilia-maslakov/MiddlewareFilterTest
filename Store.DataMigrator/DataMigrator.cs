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
            return (TCTX)Activator.CreateInstance(typeof(TCTX), dbOptionConf(new DbContextOptionsBuilder<TCTX>()));
        }
    }
}