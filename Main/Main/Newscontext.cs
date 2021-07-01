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
    class Newscontext:DbContext
    {
        public Newscontext():base("NewsDataBase")
        {
            Database.SetInitializer(
              new DropCreateDatabaseIfModelChanges<Newscontext>()
              );
        }
        public DbSet<News> News { get; set; }
    }
}
