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

}