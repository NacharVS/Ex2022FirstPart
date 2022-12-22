using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using ExamWPFApp.Data;

namespace ExamWPFApp.Data
{
    public class MongoExamples
    {
        public static void AddToDB(Customer customer)
        {
            var client = new MongoClient();
            var database = client.GetDatabase("CustomerDB");
            var collection = database.GetCollection<Customer>("Customers");
            collection.InsertOne(customer);

        }
        public static void AddPurchaseHistoryToDB(PurchaseHistory purchaseHistory)
        {
            var client = new MongoClient();
            var database = client.GetDatabase("PurchaseHistoryDB");
            var collection = database.GetCollection<PurchaseHistory>("PurchaseHistory");
            collection.InsertOne(purchaseHistory);

        }
        /*
                public static List<Character> FindAll()
                {
                    var client = new MongoClient();
                    var database = client.GetDatabase("CharacterDB");
                    var collection = database.GetCollection<Character>("Characters");
                    var list = collection.Find(x => true).ToList();
                    return list;
                }
        */
        public static Customer Find(string name)
        {
            var client = new MongoClient();
            var database = client.GetDatabase("CustomerDB");
            var collection = database.GetCollection<Customer>("Customers");
            var one = collection.Find(x => x.Name == name).FirstOrDefault();
            return one;
/*
            Console.WriteLine($" {one?.Name} {one?.Email} {one?.Age} {one?.DriverCard}");*/


        }

        public static void ReplaceByName(string name, Customer customer)
        {
            var client = new MongoClient();
            var database = client.GetDatabase("CustomerDB");
            var collection = database.GetCollection<Customer>("Customers");
            collection.ReplaceOne(x => x.Name == name, customer);
        }
    }
}
