using MongoDB.Driver;
using MongoDB.Bson;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

public class DBConnector{
    private MongoClient _dbConnection;
    private IMongoDatabase _database;
    private IMongoCollection<Dish> _recipeCollection;

    public DBConnector(){
        initDBConnection();
    }

    //Function: init the DB Connection
    private void initDBConnection(){
        //Note: This is not considered safe but done for test reasons.
        //See https://www.mongodb.com/docs/drivers/csharp/current/quick-start/#std-label-csharp-quickstart
        string conString = "mongodb://localhost:27017/cookbook";

        _dbConnection = new MongoClient(conString);
        _database = _dbConnection.GetDatabase("cookbook");
        _recipeCollection = _database.GetCollection<Dish>("recipes");
        Console.WriteLine("DB Set up and connection ready!");
    }

    //Function: add entry
    public void addDish(Dish dish){
        _recipeCollection.InsertOne(dish);
    }

    //Function: edit entry
    public void editDish(ObjectId id, Dish dish){
        var filter = Builders<Dish>.Filter.Eq(dish => dish.Id, id);
            var update = Builders<Dish>.Update
            .Set(newDish => newDish.Title, dish.Title)
            .Set(newDish => newDish.CookingTime, dish.CookingTime)
            .Set(newDish => newDish.Image, dish.Image)
            .Set(newDish => newDish.Description, dish.Description)
            .Set(newDish => newDish.Ingredients, dish.Ingredients)
            .Set(newDish => newDish.Steps, dish.Steps);
        _recipeCollection.UpdateOne(filter, update);
    }

    //Function: remove entry
    public void deleteDish(ObjectId id){
        _recipeCollection.DeleteOne(targetDish => targetDish.Id==id);
    }
    //Function: Get all entries
    public string getAllDishes(){
        List<Dish> allDishes = _recipeCollection.Find(_ => true).ToList();
        return JsonConvert.SerializeObject(allDishes);
    }

    //DebugFunction: Wipe DB and write debug data
    public void resetDB(){
        //1. Delete all documents inside collection
        var filter = Builders<Dish>.Filter.Empty;
        _recipeCollection.DeleteMany(filter);

        //2. Load documents from static file as List
        //From https://stackoverflow.com/questions/17405180/how-to-read-existing-text-files-without-defining-path
        var path = Path.Combine(Directory.GetCurrentDirectory(), "Data/debugData.json");   
        var jsonFile = File.ReadAllText(path);

        JArray jsonArray = JArray.Parse(jsonFile);
        var dishes = jsonArray.ToObject<List<Dish>>();
        
        //3. Add documents to mongoDB
        _recipeCollection.InsertMany(dishes);
    }
}
