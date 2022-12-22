using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace ExamWPFApp.Data
{
    public class Customer
    {
        [BsonIgnoreIfDefault]
        [BsonId]
        ObjectId _id;

        public Customer(string name, string surname, DateTime birthDate, string login, string password)
        {
            Name = name;
            Surname = surname;
            BirthDate = birthDate;
            Login = login;
            Password = password;
            Account = 0;
        }

        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime BirthDate { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public int Account { get; set; }
    }
}
