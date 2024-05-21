using MongoDB.Driver;
using MongoDB.Bson;
using Newtonsoft.Json;

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

    //Function: remove entry
    public void deleteDish(ObjectId id){
        _recipeCollection.DeleteOne(a => a.Id==id);
    }
    //Function: Get all entries

    //DebugFunction: Wipe DB and write debug data

    //DebugFunction: Smoketest
}
