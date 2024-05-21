using MongoDB.Bson;
using Newtonsoft.Json;


var builder = WebApplication.CreateBuilder(args);

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

//Init DB Connector
DBConnector con = new DBConnector();

/*
API - Prod
*/
app.MapGet("/", () => {
    return "Greetings. Cookbook backend ready for instructions.";
});

app.MapPost("/createDish", async (HttpContext context) => {
    var reader = new StreamReader(context.Request.Body);
    var requestBody = await reader.ReadToEndAsync();

    Dish dishData = JsonConvert.DeserializeObject<Dish>(requestBody);

    /*
    TODO: Implement some sort of input validation here!
    if(myValidationFunction(bodyJson) === false){
        return "Dish Object malformed or missing";
    }
    */

    con.addDish(dishData);

    return "Created dish";
});

app.MapPatch("/editDish", ()=>{});

app.MapDelete("/deleteDish/{id}", (ObjectId id)=>{
    con.deleteDish(id);
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
