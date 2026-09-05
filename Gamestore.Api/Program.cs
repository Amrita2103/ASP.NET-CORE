
using Gamestore.Api.Data;
using Gamestore.Api.Dtos;
using Gamestore.Api.Endpoints;
var builder = WebApplication.CreateBuilder(args);
// we need to acivate or register validation services 
// using builder object
builder.Services.AddValidation(); 
// validation services will be registered with every single 
// endpoint in our application 
// we can add DBContext using dependency injection 
// define the connection string to connect to the SQLite database and 
// how to register our DBContext with that connection string 
// must be done before ceation of app object 
var connString = "Data Source=GameStore.db";
builder.Services.AddSqlite<GamestoreContext>(connString);
var app = builder.Build();
app.MapGamesEndpoints();
app.MigrateDb();
app.Run(); // run the instance 
