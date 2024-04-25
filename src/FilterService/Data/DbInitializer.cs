using System.Text.Json;
using MongoDB.Driver;
using MongoDB.Entities;

namespace FilterService;

public class DbInitializer
{
    public static async Task InitDb(WebApplication app)
    {
        await DB.InitAsync("FilterDb", MongoClientSettings
            .FromConnectionString(app.Configuration.GetConnectionString("MongoDbConnection")));

        await DB.Index<Bidding>()
            .Key(p => p.Company, KeyType.Text)
            .Key(p => p.ModelNo, KeyType.Text)
            .Key(p => p.Colour, KeyType.Text)
            .CreateAsync();


        var items = await DB.CountAsync<Bidding>();

        if (items == 0)
        {
            Console.WriteLine("DB empty, will try to seed");
            var biddingData = await File.ReadAllTextAsync("Data/biddings.json");

            var options = new JsonSerializerOptions{PropertyNameCaseInsensitive = true};

            var biddings = JsonSerializer.Deserialize<List<Bidding>>(biddingData, options);

            await DB.SaveAsync(biddings);

        }
    }
}
