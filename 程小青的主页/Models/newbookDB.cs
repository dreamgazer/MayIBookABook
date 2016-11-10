using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Mayibookabook.Models
{
    public class newbookDB:DbContext
    {
        public DbSet<book> books { get; set; }
        public DbSet<person> borrowers { get; set; }
    }
}