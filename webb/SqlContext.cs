
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
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
        public DbSet<Login> Logins { get; set; }
    }
}
