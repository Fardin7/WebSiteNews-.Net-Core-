using Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
namespace DAL
{
   public class Context : IdentityDbContext
    {
        public Context(DbContextOptions<Context> options) : base(options)
        {
           
        }
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer(@"Server=(localdb)\\mssqllocaldb;Database=CoreDatabase;Trusted_Connection=True;MultipleActiveResultSets=true");
        //}

        public virtual DbSet<Permission> Permissions { get; set; }

        public virtual DbSet<News> News { get; set; }
        public virtual DbSet<Contact> Contacts { get; set; }
        public virtual DbSet<Category> Categories{ get; set; }
        public virtual DbSet<Subcategory> Subcategories { get; set; }
        public virtual DbSet<NewsSubCategory> NewsSubCategories { get; set; }
        public virtual DbSet<NewsCategory> NewsCategories { get; set; }
        public virtual DbSet<NewsFile> NewsFiles { get; set; }
        public virtual DbSet<Comment> Comment { get; set; }
        public virtual DbSet<NewsLetter> NewsLetter { get; set; }

    }


    public class YourDbContextFactory : IDesignTimeDbContextFactory<Context>
    {
        public Context CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<Context>();
            optionsBuilder.UseSqlServer("Server=.;Database=CoreDatabase;Trusted_Connection=True;MultipleActiveResultSets=true");

            return new Context(optionsBuilder.Options);
        }
    }
}
