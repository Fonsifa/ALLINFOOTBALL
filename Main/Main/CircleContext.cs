using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data;
using System.Data.SqlClient;
using System.Data.Entity;
using System.Threading.Tasks;

namespace Main
{
    class CircleContext : DbContext
    {
        public CircleContext() : base("CircleDataBase")
        {
            Database.SetInitializer(
              new DropCreateDatabaseIfModelChanges<CircleContext>()
              );
        }
        public DbSet<Circles> circles { get; set; }
        public DbSet<Comment> comments { get; set; }
    }
}
