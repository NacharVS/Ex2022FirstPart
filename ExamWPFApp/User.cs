using System;
using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.Options;

namespace ExamWPFApp
{
    public class User
    {
        public User(string firstName, string lastName, string login, string password, DateTime birthDate)
        {
            FirstName = firstName;
            LastName = lastName;
            Login = login;
            Password = password;
            BirthDate = birthDate;
            ShoppingBasket = new List<Product>();
        }

        [BsonId]
        [BsonIgnoreIfDefault]
        ObjectId id;
        public string FirstName { get; set; }
		public string LastName { get; set; }
		public string Login { get; set; }
		public string Password { get; set; }
		public DateTime BirthDate { get; set; }
        public int CashAccount { get; set; }

        [BsonIgnoreIfNull]
        public List<Product> ShoppingBasket { get; set; }
	}
}