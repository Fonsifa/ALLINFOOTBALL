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
    class Gamecontext:DbContext
    {
        public Gamecontext() : base("GameDB")
        {
            Database.SetInitializer(
              new DropCreateDatabaseIfModelChanges<Gamecontext>()
              );
        }
        public DbSet<Game> games { set; get; }
    }
}
