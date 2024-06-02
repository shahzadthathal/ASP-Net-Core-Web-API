using ASPNetCoreWebAPI_Reactjs.Data;
using ASPNetCoreWebAPI_Reactjs.Interfaces;
using ASPNetCoreWebAPI_Reactjs.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<ApplicationDBContext>(options => {
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

builder.Services.AddScoped<DbInitializer>();

// Dependency Injection
builder.Services.AddScoped<ICategory, CategoryRepository>();
builder.Services.AddScoped<IPost, PostRepository>();
builder.Services.AddScoped<IComment, CommentRepository>();

var app = builder.Build();

// Ensure database is created and seeded.
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var logger = services.GetRequiredService<ILogger<Program>>();
    try
    {
        var dbContext = services.GetRequiredService<ApplicationDBContext>();
        dbContext.Database.Migrate(); // Apply any pending migrations
        logger.LogInformation("Database migration completed.");

        var initializer = services.GetRequiredService<DbInitializer>();
        initializer.Initialize();
        logger.LogInformation("Database seeding completed.");
    }
    catch (Exception ex)
    {
        logger.LogError(ex, "An error occurred during migration and seeding the database.");
    }
}

// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
    app.UseSwagger();
    app.UseSwaggerUI();
//}

app.UseAuthorization();

app.MapControllers();

app.Run();
