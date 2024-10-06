using Microsoft.EntityFrameworkCore;

namespace WebAPP_with_SQLite_WASM.Client
{
    public class ThingContext : DbContext
    {
        public ThingContext(DbContextOptions<ThingContext> opts) : base(opts)
        {

        }

        public DbSet<Thing> Things { get; set; } = null!;
    }
}
