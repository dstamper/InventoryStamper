using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.Entity;
using System.Data.Entity.Core.Common;
using System.Data.Entity.Infrastructure;
using System.Data.SQLite;
using System.Data.SQLite.EF6;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InventoryStamper.Data.Configuration;
using InventoryStamper.Models;
using SQLite.CodeFirst;

namespace InventoryStamper.Data
{
    [DbConfigurationType(typeof(SQLiteDbContextConfiguration))]
    public class TestDBContext : DbContext
    {

        public DbSet<InventoryItem> TestSet { get; set; }
        
        public TestDBContext()
            : base("ConnectionString") { }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            var output = Database.Connection.ConnectionString;
            Console.WriteLine(output);
            var connectionInit = new SqliteCreateDatabaseIfNotExists<TestDBContext>(modelBuilder);
            Database.SetInitializer(connectionInit);
        }        
    }
}
