var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();


//Init DB Connector

//Init CORS


/*
API - Prod
*/
app.MapGet("/", () => {
    DBConnector con = new DBConnector();
    return "Greetings mate! DB initialized!";
});

/*
API - Debug
*/

app.Run();
//initDBConnection();
