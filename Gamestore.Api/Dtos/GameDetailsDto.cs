namespace Gamestore.Api.Dtos;

// our first dto and we are going to use it with our api 
public record class GameDetailsDto(
    int Id,
    string GameName,
    int GenreId,
    decimal Price,
    DateOnly ReleaseDate

);
