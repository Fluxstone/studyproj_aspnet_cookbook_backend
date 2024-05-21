using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

public class Dish
{
    [BsonElement("_id")]
    public ObjectId Id { get; set; }

    [BsonElement("dish_title")]
    public string Title { get; set; }

    [BsonElement("dish_cookingTime")]
    public int CookingTime { get; set; }

    [BsonElement("dish_image")]
    public string Image { get; set; }

    [BsonElement("dish_description")]
    public string Description { get; set; }

    [BsonElement("dish_ingredients")]
    public List<string> Ingredients { get; set; }

    [BsonElement("dish_steps")]
    public List<string> Steps { get; set; }
}