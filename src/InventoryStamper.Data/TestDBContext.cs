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
using InventoryStamper.Models;
using SQLite.CodeFirst;

namespace InventoryStamper.Data
{
    [DbConfigurationType(typeof(MyDbContextConfiguration))]
    public class TestDBContext : DbContext
    {

        public DbSet<InventoryItem> Inventory { get; set; }


        public TestDBContext()
            : base() { }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            var output = Database.Connection.ConnectionString;
            Console.WriteLine(output);
            var connectionInit = new SqliteCreateDatabaseIfNotExists<TestDBContext>(modelBuilder);
            Database.SetInitializer(connectionInit);
        }
        
    }

    internal class MyDbContextConfiguration : DbConfiguration
    {
        public MyDbContextConfiguration()
        {
            SetDefaultConnectionFactory(new SQLiteConnectionFactory());
            SetProviderFactory("System.Data.SQLite", SQLiteFactory.Instance);
            SetProviderFactory("System.Data.SQLite.EF6", SQLiteProviderFactory.Instance);
            SetProviderServices("System.Data.SQLite", (DbProviderServices)SQLiteProviderFactory.Instance.GetService(typeof(DbProviderServices)));
        }
    }

    public class SQLiteConnectionFactory : IDbConnectionFactory
    {
        public DbConnection CreateConnection(string nameOrConnectionString)
        {
            SQLiteConnectionStringBuilder builder = new SQLiteConnectionStringBuilder();
            builder.DataSource = @".\db\test\test.sqlite";
            builder.ForeignKeys = true;
            return new SQLiteConnection(builder.ConnectionString);
        }
    }


}
