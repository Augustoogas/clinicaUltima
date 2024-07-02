

using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04_Persistencia_de_datos.MongoDBConnector
{
    public class MongoDBConnectionSingleton
    {

        private static MongoDBConnectionSingleton instance = null;




        private readonly IMongoClient mongoClient;
        private readonly IMongoDatabase mongoDatabase;


        private MongoDBConnectionSingleton(string connectionString, string databaseName)
        {
            mongoClient = new MongoClient(connectionString);
            mongoDatabase = mongoClient.GetDatabase(databaseName);
        }


        public static MongoDBConnectionSingleton Instance(string connectionString, string databaseName)
        {

            if (instance == null)
            {
                instance = new MongoDBConnectionSingleton(connectionString, databaseName);
            }
            return instance;

        }


        public IMongoClient GetClient()
        {

            return mongoClient;
        }

        public IMongoDatabase GetDatabase()
        {
            return mongoDatabase;
        }


    }
}
