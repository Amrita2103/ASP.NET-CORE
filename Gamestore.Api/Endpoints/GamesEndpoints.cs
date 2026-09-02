// will contain all of our api endpoints  
using Gamestore.Api.Dtos;

namespace Gamestore.Api.Endpoints;
public static  class GamesEndpoints
{
    
private static readonly List<GameDto> games = new List<GameDto>{new(1, "Street Fighting II", "Fighting", 19.99M, new DateOnly(1992,7,15)),
new(2, "Final Fantasy VII rebirth", "RPG", 69.99M, new DateOnly(2024,2,29)),
new(3, "Astro Bot", "Platformer", 59.99M, new DateOnly(2024,9,6))

};
public static void MapGamesEndpoints ( this WebApplication app)
    {

var group = app.MapGroup("/games");
//GET endpoint and is going to return all games at any time 
 group.MapGet("/", () => games);

//GET /games/1
// to retrieve a particular game from the list
group.MapGet("/{id}", (int id) => {
   var req = games.Select(g =>g).Where(g => g.Id == id).ToList();
   return req.Count == 0? Results.NotFound(): Results.Ok(req);
})
.WithName("GetGame");

//POST /games
group.MapPost("/" , (CreateGameDto newGame) => {GameDto obj = new GameDto(
      games.Count +1,
      newGame.Name,
      newGame.Genre,
      newGame.Price,
      newGame.ReleaseDate

); 
     games.Add(obj);
     // we want to return the payload of the created result
     // to the user 
     return Results.CreatedAtRoute("GetGame", new{id = obj.Id}, obj);
});


// PUT games/1
group.MapPut("/{id}", (int id, UpdateGameDto obj) =>
{
    var index = games.FindIndex(g => g.Id == id);
    if(index == -1)
    {
        return Results.NotFound();
    }
    games[index] = new GameDto(
     id,
     obj.Name,
     obj.Genre,
     obj.Price,
     obj.ReleaseDate
    );
    return Results.NoContent();
} );


//DELETE games/1
// makes sure the resource does not exist 
// after the end point is processed regardless if it 
// existed or not before 
group.MapDelete("/{id}", (int id) =>
{
    games.RemoveAll(g => g.Id == id);
    return Results.NoContent();
} ); 



    }
}