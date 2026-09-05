
namespace Gamestore.Api.Models;
public class Game
{
   public int Id {get; set;}
   public required string Name {get; set;}    

   public Genre? Genre { get; set;}
   // composite property of the game model - a kind of navigation 
   // property in a game model 
   // this will be a foreign key from our game table into our genre table 

   // we can also have a FK like the following :
   public int Genre_Id { get; set;}
  // we can easily work directly with the genre_id instead of having to load 
  // the entire Genre Property 
  public decimal Price {get; set;}
  public DateOnly ReleaseDate {get; set;}
   }


