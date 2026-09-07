// will contain all of our api endpoints  
using Gamestore.Api.Data;
using Gamestore.Api.Dtos;
using Gamestore.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace Gamestore.Api.Endpoints;
public static  class GamesEndpoints
{
    

public static void MapGamesEndpoints ( this WebApplication app)
    {

var group = app.MapGroup("/games");
//GET endpoint and is going to return all games at any time 
 group.MapGet("/", async(GamestoreContext dbContext) => await dbContext.Games.
                                                                        Include(games => games.Genre)
                                                                        .Select(games => new GameDto(games.Id,games.Name,games.Genre!.Name, games.Price, games.ReleaseDate)).AsNoTracking(). ToListAsync());

//GET /games/1
// to retrieve a particular game from the list
group.MapGet("/{id}", async(int id, GamestoreContext dbContext) => {
   var req = await dbContext.Games.FindAsync(id);
   return req is null? Results.NotFound(): Results.Ok(new GameDetailsDto(
     
          req.Id,
          req.Name,
          req.GenreId,
          req.Price,
         req.ReleaseDate
     ));
})
.WithName("GetGame");

//POST /games
group.MapPost("/" , async(CreateGameDto newGame, GamestoreContext dbContext) => {Game game1 = new()
{
  Name = newGame.Name,
  GenreId = newGame.GenreId,
  Price = newGame.Price,
  ReleaseDate = newGame.ReleaseDate
};
     dbContext.Games.Add(game1); //  a new game needs to be inserted into the db
     await dbContext.SaveChangesAsync(); // converts any pending changes to sql statements the db can understand 
     // we want to return the payload of the created result
     // to the user 
     GameDetailsDto obj = new(
     
          game1.Id,
          game1.Name,
          game1.GenreId,
          game1.Price,
         game1.ReleaseDate
     );
     return Results.CreatedAtRoute("GetGame", new{id = obj.Id}, obj);
});


// PUT games/1
group.MapPut("/{id}",async (int id, UpdateGameDto obj, GamestoreContext dbContext) =>
{
    var existing_game = await dbContext.Games.FindAsync(id);
    if(existing_game is null)
    {
        return Results.NotFound();
    }
   existing_game.Name = obj.Name;
   existing_game.GenreId= obj.GenreId;
   existing_game.Price = obj.Price;
   existing_game.ReleaseDate = obj.ReleaseDate;
   await dbContext.SaveChangesAsync();
    return Results.NoContent();
} );


//DELETE games/1
// makes sure the resource does not exist 
// after the end point is processed regardless if it 
// existed or not before 
group.MapDelete("/{id}", async(int id, GamestoreContext dbContext) =>
{
    await dbContext.Games.Where( game => game.Id == id).ExecuteDeleteAsync();
    return Results.NoContent();
} ); 



    }
}