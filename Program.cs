using MongoDB.Bson;

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
DBConnector con = new DBConnector();

/*
API - Prod
*/
app.MapGet("/", () => {
    return "Greetings. Cookbook backend ready for instructions.";
});

app.MapPost("/createDish", ()=>{});

app.MapPatch("/editDish", ()=>{});

app.MapDelete("/deleteDish/{id}", (ObjectId id)=>{
    return $"Deleted Item with ID {id}";
});


/*
API - Debug
*/

app.MapPost("/debug/dbReset", () => {
    return "DB Reset!";
});

app.MapPost("/debug/smoketest", () => {
    return "Connection successfull!";
});

app.UseCors(MyAllowSpecificOrigins);
app.Run();
