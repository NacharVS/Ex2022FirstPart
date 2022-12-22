using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamWPFApp
{
    internal class User
    {
        public User(string firstName, string lastName, string login, string password, DateOnly birthDate)
        {
            FirstName = firstName;
            LastName = lastName;
            Login = login;
            Password = password;
            BirthDate = birthDate;
        }

        public string FirstName { get; set; }
		public string LastName { get; set; }
		public string Login { get; set; }
		public string Password { get; set; }
		public DateOnly BirthDate { get; set; }

	}
}
/*
 * 1. Регистрация:	
	Поля:
	а) Имя
	б) Фамилия
	в) Дата рождения
	г) Логин
	д) Пароль
	е) Повтор пароля
*/