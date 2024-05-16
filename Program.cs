var builder = WebApplication.CreateBuilder(args);



//Init DB Connector

//Init CORS
var  MyAllowSpecificOrigins = "_cookbook_frontend";
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
                      builder =>
                      {
                          builder.WithOrigins("http://localhost:4200") // Allow Angular frontend
                                 .AllowAnyHeader()
                                 .AllowAnyMethod();
                      });
});

var app = builder.Build();

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

app.MapGet("/debug/smoketest", () => {
    return "Connection successfull!";
});
app.UseCors(MyAllowSpecificOrigins);
app.Run();
