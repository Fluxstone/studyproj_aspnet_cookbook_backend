var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();


//Init DB Connector

//Init CORS


/*
API - Prod
*/
app.MapGet("/", () => "Hello World!");

/*
API - Debug
*/

app.Run();
