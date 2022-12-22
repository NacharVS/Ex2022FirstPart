using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Driver;

namespace ExamWPFApp
{
    public class MongoDb
    {
        static MongoClient client;
        static IMongoDatabase ExemDatabase;
        static IMongoCollection<User> UserCollection;
        static MongoDb()
        {
            client = new MongoClient();
            ExemDatabase = client.GetDatabase("ExemDb");
            UserCollection = ExemDatabase.GetCollection<User>("Users");
        }
        public static User FindUser(string login)
        {
            return UserCollection.Find(x => x.Login == login).FirstOrDefault();
        }
        public static void AddUser(User user)
        {
            UserCollection.InsertOne(user);
        }
    }
}
