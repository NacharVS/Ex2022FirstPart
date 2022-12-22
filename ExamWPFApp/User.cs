using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.Options;

namespace ExamWPFApp
{
    internal class User
    {
        public User(string firstName, string lastName, string login, string password, DateTime birthDate)
        {
            FirstName = firstName;
            LastName = lastName;
            Login = login;
            Password = password;
            BirthDate = birthDate;
        }

        [BsonId]
        [BsonIgnoreIfDefault]
        ObjectId id;
        public string FirstName { get; set; }
		public string LastName { get; set; }
		public string Login { get; set; }
		public string Password { get; set; }
		public DateTime BirthDate { get; set; }

	}
}