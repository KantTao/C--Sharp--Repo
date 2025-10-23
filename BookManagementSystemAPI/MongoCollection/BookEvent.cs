using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace BookManagementSystemAPI.MongoCollection;

public class BookEvent
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]//C#的string类型 转换成 object Id 
    public string Id { get; set; }
    
    public int BookId { get; set; }
    
    public string EventNote { get; set; }

    public int AuthorId { get; set; }

    

} 