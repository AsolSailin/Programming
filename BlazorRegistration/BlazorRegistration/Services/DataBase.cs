
using MongoDB.Bson;
using MongoDB.Driver;
using BlazorRegistration.Data;

namespace BlazorRegistration.Services;
public class DataBase
{
    public User? CurrentUser { get; set; }
        
    public void AddToDataBase(User user)
    {
        MongoClient client = new MongoClient("mongodb://localhost");
        IMongoDatabase database = client.GetDatabase("Registration");
        var collection = database.GetCollection<User>("UsersList");
        collection.InsertOne(user);
    }
    public async Task<User> FindByLoginAsync(string login)
    {
        await Task.Delay(3000);
        MongoClient client = new MongoClient("mongodb://localhost");
        IMongoDatabase database = client.GetDatabase("Registration");
        var collection = database.GetCollection<User>("UsersList");
        var user = collection.Find(x => x.Login == login).FirstOrDefault();

        return user;
    }
}