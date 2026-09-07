using System.ComponentModel.DataAnnotations;

namespace Gamestore.Api.Dtos;

public record CreateGameDto
(
    // we are not including id as ids are usually
    //generated and provided by the server 
    // after the reource is created (we don't get it directly from client)
    [Required] [StringLength(50)] string Name,
    [Range(1,50)] int GenreId,
    [Range(1,100)] decimal Price,
    DateOnly ReleaseDate
);