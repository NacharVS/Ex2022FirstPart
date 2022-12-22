using System;
using System.Collections.Generic;
using System.Linq;
using MongoDB.Driver;

namespace ExamWPFApp
{
    internal class UserMongoDB
    {
        static string dataBaseName = "UsersBase";
        static string unitCollectionName = "Users";
        static string itemCollectionName = "PurchaseData";
        static MongoClient client;
        static IMongoDatabase database;
        static IMongoCollection<User> userCollection;
        static IMongoCollection<object> purchaseDataCollection;

        static UserMongoDB()
        {
            client = new MongoClient();
            database = client.GetDatabase(dataBaseName);
            userCollection = database.GetCollection<User>(unitCollectionName);
            purchaseDataCollection = database.GetCollection<object>(itemCollectionName);
        }

        public static void AddPurchaseDataTodataBase(String name, List<Product> products, int Cost)
        {
            DateTime now = DateTime.Now;
            purchaseDataCollection.InsertOne(new {name, products, Cost, now});
        }

        public static void AddUserTodataBase(User user)
        {
            userCollection.InsertOne(user);
        }

        public static List<User> FindAllUsers()
        {
            return userCollection.Find(x => true).ToList();
        }

        public static void ReplaceUser(string login, User user)
        {
            userCollection.ReplaceOne(x => x.Login == login, user);
        }

        public static User FindUser(string login)
        {
            return userCollection.Find(x => x.Login == login).FirstOrDefault();
        }
    }
}
