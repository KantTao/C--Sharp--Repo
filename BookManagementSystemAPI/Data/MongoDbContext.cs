using BookManagementSystemAPI.MongoCollection;
using Microsoft.CodeAnalysis.Options;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace BookManagementSystemAPI.Data;

public class MongoDbContext
{
    private readonly IMongoDatabase _database;
    private readonly string _BookCollectionName;
    
    public MongoDbContext(IOptions<MongoDbSettings> mongoDbSettings)
    {
        var client = new MongoClient(mongoDbSettings.Value.ConnectionString);
        _database = client.GetDatabase(mongoDbSettings.Value.DataBaseName);
        _BookCollectionName = mongoDbSettings.Value.BookEventCollectionName;
    }
    
    //自定义的BookEvent 
    public IMongoCollection<BookEvent> BookEvents => _database.GetCollection<BookEvent>(_BookCollectionName);
    
}