using MongoDB.Driver;
using MongoDB.Bson;
using Newtonsoft.Json;

public class DBConnector{
    private MongoClient _dbConnection;


    public DBConnector(){
        initDBConnection();
    }

    //Function: init the DB Connection
    private void initDBConnection(){
        //Note: This is not considered safe but done for test reasons.
        //See https://www.mongodb.com/docs/drivers/csharp/current/quick-start/#std-label-csharp-quickstart
        string conString = "mongodb://localhost:27017/cookbook";

        this._dbConnection = new MongoClient(conString);
    }

    //Function: add entry

    //Function: edit entry

    //Function: remove entry

    //Function: Get all entries

    //DebugFunction: Wipe DB and write debug data

    //DebugFunction: Smoketest
}
