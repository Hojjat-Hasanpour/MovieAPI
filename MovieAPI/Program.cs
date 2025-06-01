using Microsoft.EntityFrameworkCore;
using MovieAPI.Data;
using MovieAPI.Endpoints;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<MovieContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("MovieDB_net8")));

var app = builder.Build();

//Use Connection String from AppSettings.json
//builder.Services.AddDbContext<MovieContext>(options =>
//options.UseSqlServer(builder.Configuration.GetConnectionString("MovieDB_net8"))
//);


//Asynchronous method to seed data into our database
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    try
    {
        var context = services.GetRequiredService<MovieContext>();
        await context.Database.MigrateAsync();
    }
    catch (Exception ex)
    {
        Console.WriteLine($"An error has occured while migrating the database: {ex.Message}");
    }
}
app.MapGet("/", () => "Hello World!");
app.MapMovieEndpoints();
app.MapGenresEndpoints();
app.Run();
