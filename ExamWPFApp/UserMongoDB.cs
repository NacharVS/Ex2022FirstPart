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
        static string itemCollectionName = "Items";
        static MongoClient client;
        static IMongoDatabase database;
        static IMongoCollection<User> userCollection;

        static UserMongoDB()
        {
            client = new MongoClient();
            database = client.GetDatabase(dataBaseName);
            userCollection = database.GetCollection<User>(unitCollectionName);
            //itemCollection = database.GetCollection<Item>(itemCollectionName);
        }

        public static void AddUnitTodataBase(User user)
        {
            userCollection.InsertOne(user);
        }

        public static List<User> FindAllUnits()
        {
            return userCollection.Find(x => true).ToList();
        }


        public static void ReplaceUnit(string login, User user)
        {
            userCollection.ReplaceOne(x => x.Login == login, user);
        }

        public static User FindUnit(string login)
        {
            return userCollection.Find(x => x.Login == login).FirstOrDefault();
        }
    }
}
