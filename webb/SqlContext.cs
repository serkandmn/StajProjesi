
using Microsoft.EntityFrameworkCore;
using webb.Models;

namespace webb
{
    public class SqlContext : DbContext
    {
        public SqlContext(DbContextOptions<SqlContext> options) : base(options)
        {

        }
        public SqlContext()
        {

        }

        public DbSet<kisibilgileri> bilgis { get; set; }
    }
}
