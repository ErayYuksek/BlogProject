using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Concrete.Context
{
    internal class Context:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server =ERAY\\SQLEXPRESS; database=BlogLiveDb; integrated security=true;TrustServerCertificate=True");

            //optionsBuilder.UseSqlServer("server =205.144.171.18; database=db_a88619_smtblog; user=smtcoder-001; Password=Akca1975");

            //optionsBuilder.UseSqlServer("Data Source = SQL5109.site4now.net; Initial Catalog = db_a88619_smtblog; User Id = db_a88619_smtblog_admin; Password =Akca1975");
        }


        public DbSet<About> Abouts { get; set; }
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Writer> Writers { get; set; }
     
    }
}
