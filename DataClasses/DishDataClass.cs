using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using Newtonsoft.Json;

public class Dish
{
    [BsonElement("_id")]
    [JsonProperty("_id")]
    public ObjectId Id { get; set; }

    [BsonElement("dish_title")]
    [JsonProperty("dish_title")]
    public string Title { get; set; }

    [BsonElement("dish_cookingTime")]
    [JsonProperty("dish_cookingTime")]
    public int CookingTime { get; set; }

    [BsonElement("dish_image")]
    [JsonProperty("dish_image")]
    public string Image { get; set; }

    [BsonElement("dish_description")]
    [JsonProperty("dish_description")]
    public string Description { get; set; }

    [BsonElement("dish_ingredients")]
    [JsonProperty("dish_ingredients")]
    public List<string> Ingredients { get; set; }

    [BsonElement("dish_steps")]
    [JsonProperty("dish_steps")]
    public List<string> Steps { get; set; }
}