using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using EntityFrameworkExample.Migrations;

namespace EntityFrameworkExample.Models
{
    public class CompanyDbContext:DbContext
    {
       public CompanyDbContext():base("ConnectionString")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<CompanyDbContext, Configuration>());
        }
       public  DbSet<Brand> Brands { get; set; }
        public DbSet<Catagory> Catagories { get; set; }
        public DbSet<Product> Products { get; set; }
    }
}