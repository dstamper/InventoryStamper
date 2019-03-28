using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InventoryStamper.Models;
using SQLite.CodeFirst;

namespace InventoryStamper.Data
{
    public class TestDBContext : DbContext
    {
        public DbSet<InventoryItem> Inventory { get; set; }

        public TestDBContext()
            : base("test") { }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            var connectionInit = new SqliteCreateDatabaseIfNotExists<TestDBContext>(modelBuilder);
            Database.SetInitializer(connectionInit);
        }
    }


}
