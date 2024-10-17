using MongoDB.Driver;

namespace Mentor.Application.Services;

public class MongoDbService
{
    private readonly IMongoDatabase _database;

    public MongoDbService(string connectionString, string dbName)
    {
        var client = new MongoClient(connectionString);
        _database = client.GetDatabase(dbName);
    }
    public IMongoCollection<Domain.Entities.Mentor> Mentors => _database.GetCollection<Domain.Entities.Mentor>("Mentors");

}