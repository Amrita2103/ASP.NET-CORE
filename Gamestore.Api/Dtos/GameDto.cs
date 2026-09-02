namespace Gamestore.Api.Dtos;

// our first dto and we are going to use it with our api 
public record class GameDto(
    int Id,
    string GameName,
    string Genre,
    decimal Price,
    DateOnly ReleaseDate

);
