using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamWPFApp
{
    public class User
    {
        public User (string newName, string newSurname, DateOnly newBithday, string newLogin, string newPassword, int newBalance)
        {
            Name = newName;
            Surname = newSurname;
            Bithday = newBithday;
            Login = newLogin;
            Password = newPassword;
            Balance = newBalance;
        }
        [BsonId]
        [BsonIgnoreIfDefault]
        ObjectId _id;
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateOnly Bithday { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public int Balance { get; set; }
    }
}
