using ASPNetCoreWebAPI_Reactjs.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace ASPNetCoreWebAPI_Reactjs.Data
{
    public class DbInitializer
    {
        private readonly ApplicationDBContext _context;
        private readonly ILogger<DbInitializer> _logger;

        public DbInitializer(ApplicationDBContext context, ILogger<DbInitializer> logger)
        {
            _context = context;
            _logger = logger;
        }

        public void Initialize()
        {
            _logger.LogInformation("Ensuring the database is created...");
            _context.Database.Migrate();
            _logger.LogInformation("Database is created.");

            if (_context.Categories.Any())
            {
                _logger.LogInformation("Database already seeded.");
                return; // DB has been seeded
            }

            _logger.LogInformation("Seeding database...");

            var categories = new List<Category>
            {
                new Category { Name = "Technology" },
                new Category { Name = "Health" },
                new Category { Name = "Lifestyle" }
            };

            _context.Categories.AddRange(categories);
            _context.SaveChanges();

            var posts = new List<Post>
            {
                new Post { Title = "Tech Post 1", Slug="tech-post-1", Content = "Content for tech post 1", Author = "Author 1", CategoryId = categories[0].CategoryId, CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, IsPublished = true, ImagePath = "/images/tech1.jpg" },
                new Post { Title = "Health Post 1", Slug="health-post-1", Content = "Content for health post 1", Author = "Author 2", CategoryId = categories[1].CategoryId, CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, IsPublished = true, ImagePath = "/images/health1.jpg" },
                new Post { Title = "Lifestyle Post 1", Slug="lifestyle-post-1", Content = "Content for lifestyle post 1", Author = "Author 3", CategoryId = categories[2].CategoryId, CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, IsPublished = true, ImagePath = "/images/lifestyle1.jpg" }
            };

            _context.Posts.AddRange(posts);
            _context.SaveChanges();

            var comments = new List<Comment>
            {
                new Comment { Content = "Great post!", Author = "Commenter 1", PostId = posts[0].PostId, CreatedAt = DateTime.Now },
                new Comment { Content = "Very informative.", Author = "Commenter 2", PostId = posts[1].PostId, CreatedAt = DateTime.Now },
                new Comment { Content = "I enjoyed this.", Author = "Commenter 3", PostId = posts[2].PostId, CreatedAt = DateTime.Now }
            };

            _context.Comments.AddRange(comments);
            _context.SaveChanges();

            _logger.LogInformation("Database seeded.");
        }
    }
}
