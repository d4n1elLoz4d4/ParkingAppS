using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Data.Entity;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace ParkingApp.BaseDatos
{
    public class DataBaseContext : DbContext
    {
        private const string DBName = "ParkingBd.db";

        public DataBaseContext() :
            base(new SQLiteConnection()
            {
                ConnectionString = new SQLiteConnectionStringBuilder() { DataSource = DBName, ForeignKeys = true }.ConnectionString
            }, true)
        {
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            base.OnModelCreating(modelBuilder);
        }

        public static void test()
        {
            using (var ctx = GetInstance())
            {
                var query = "select * from paths";

                using (var command = new SQLiteCommand(query, ctx))
                {
                    SQLiteDataReader reader = command.ExecuteReader();
                }
            }
        }

        public static SQLiteConnection GetInstance()
        {
            var db = new SQLiteConnection(
                string.Format("Data Source={0};Version=3;", DBName)
            );
            db.Open();

            return db;
        }

        public DbSet<Control> Control { get; set; }
    }
}
