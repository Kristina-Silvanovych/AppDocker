using AppDocker.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppDocker
{
    public class AppDBContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("host=database;port=5432;database=db;username=postgres;password=postgres");
        }

        //public AppDBContext(DbContextOptions<AppDBContext> options) : base(options) { }

        ////For Migrations
        //public class AppDBContextFactory : IDesignTimeDbContextFactory<AppDBContext>
        //{
        //    public AppDBContext CreateDbContext(string[] args)
        //    {
        //        var optionsBuilder = new DbContextOptionsBuilder<AppDBContext>();
        //        optionsBuilder.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=UserDB;Integrated Security=True;TrustServerCertificate=True;");

        //        return new AppDBContext(optionsBuilder.Options);
        //    }
        //}
    }
}
