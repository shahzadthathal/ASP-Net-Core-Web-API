using ASPNetCoreWebAPI_Reactjs.Models;
using Microsoft.EntityFrameworkCore;

namespace ASPNetCoreWebAPI_Reactjs.Data
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
        {
            
        }


        public DbSet<Post> Posts { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Comment> Comments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configuring the many-to-one relationship, each post belongs to one category
            modelBuilder.Entity<Post>()
                .HasOne(p => p.Category)
                .WithMany(c => c.Posts)
                .HasForeignKey(p => p.CategoryId);

            // Configuring the one-to-many relationship
            modelBuilder.Entity<Post>()
                .HasMany(p => p.Comments)
                .WithOne(c => c.Post)
                .HasForeignKey(c => c.PostId);

            modelBuilder.Entity<Post>()
                .HasIndex(p => p.Slug)
                .IsUnique(); // Add unique constraint

            base.OnModelCreating(modelBuilder);
        }

    }
}
