
using Gamestore.Api.Dtos;
using Gamestore.Api.Endpoints;
var builder = WebApplication.CreateBuilder(args);
// we need to acivate or register validation services 
// using builder object
builder.Services.AddValidation(); 
// validation services will be registered with every single 
// endpoint in our application 
var app = builder.Build();
app.MapGamesEndpoints();
app.Run(); // run the instance 
