using Gamestore.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace Gamestore.Api.Data;
public static class DataExtensions
{  
    public static void MigrateDb(this WebApplication app)
    {
        
// to access an instance of our GameStoreContext 
using var scope = app.Services.CreateScope();
var dbContext = scope.ServiceProvider.GetRequiredService<GamestoreContext>();
dbContext.Database.Migrate();
    } 
    public static void AddGamestoreDb(this WebApplicationBuilder builder)
    {
        var connString = builder.Configuration.GetConnectionString("GameStore");
        builder.Services.AddScoped<GamestoreContext>();
 // this is the exact moment when we register our db context with the service container 
builder.Services.AddSqlite<GamestoreContext>(connString,
optionsAction: options => options.UseSeeding((context, _)=> 
{
    if (!context.Set<Genre>().Any())
    {
        context.Set<Genre>().AddRange(
         new Genre{ Name ="Fighting"},
         new Genre{Name = "RPG"},
         new Genre{Name= "Platformer"},
         new Genre{Name = "Racing"},
         new Genre {Name = "Sports"}

        );
        context.SaveChanges();
    }
}));
        
    }

}