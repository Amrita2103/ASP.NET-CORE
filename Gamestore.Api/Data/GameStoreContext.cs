using Gamestore.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace Gamestore.Api.Data;
// in order to connect to the database 
//several parameters including the connection string are going to be received as part of these options
public class GamestoreContext(DbContextOptions<GamestoreContext> options) :DbContext(options)
{
    public DbSet<Game> Games => Set<Game>(); // property that is going to point directly to a set of Game
// this DBSet is really an object that can be used to both query and save instances of Game in this case 
// any linq queries that we are gonna send to the Games object are 
// going to be translated into queries against the database 
public DbSet<Genre> Genres => Set<Genre>();

}