using System;
using MongoDB.Driver;
using MongoDB.Bson;
using System;
using System.IO;
using System.Collections.Generic;

namespace momo;

public class Runner {

    public static void EnvSetup() {
        Environment.SetEnvironmentVariable("MONGODB_URI", "mongodb+srv://rokoban:F1xhHgjB9hBkGmcj@metrocluster.naf11.mongodb.net/?retryWrites=true&w=majority&appName=MetroCluster");
    }

    public static void Run(string[] args) {
        var connectionString = Environment.GetEnvironmentVariable("MONGODB_URI");
        if (connectionString == null)
        {
            Console.WriteLine("You must set your 'MONGODB_URI' environment variable. To learn how to set it, see https://www.mongodb.com/docs/drivers/csharp/current/quick-start/#set-your-connection-string");
            Environment.Exit(0);
        }

        var client = new MongoClient(connectionString);
        var collection = client.GetDatabase("sample_mflix").GetCollection<BsonDocument>("movies");
        var filter = Builders<BsonDocument>.Filter.Eq("title", "Back to the Future");
        var document = collection.Find(filter).First();
        Console.WriteLine(document);
    } 
}