using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ExamWPFApp
{
    /// <summary>
    /// Логика взаимодействия для RegistrationPage.xaml
    /// </summary>
    public partial class RegistrationPage : Page
    {
        public RegistrationPage()
        {
            InitializeComponent();
        }

        private void RegBtn_Click(object sender, RoutedEventArgs e)
        {
            if(Name.Text != "" && Surname.Text != "" && Birthday.Text != "" && Login.Text != "" && Password.Password != "" && RepPassword.Password != "")
            {
                if(Password.Password == RepPassword.Password)
                {
                    if(MongoDb.FindUser(Login.Text) == null)
                    {
                        string[] str = Birthday.Text.Split('.');
                        if (str[0].Length == 4 && str[1].Length == 2 && str[2].Length == 2 && str.Length == 3)
                        {
                            MongoDb.AddUser(new User(Name.Text, Surname.Text, new DateOnly(Int32.Parse(Birthday.Text.Split('.')[2]), Int32.Parse(Birthday.Text.Split('.')[1]), Int32.Parse(Birthday.Text.Split('.')[0])), Login.Text, Password.Password, 0));
                        }
                        else
                        {
                            MessageBox.Show("Incorect data. Write like 'YYYY.MM.DD'");
                        }
                    }
                    else
                    {
                        MessageBox.Show("A person with this login exists");
                    }
                }
                else
                {
                    MessageBox.Show("Passwords do not match");
                }
            }
            else
            {
                MessageBox.Show("Not all fields are filled");
            }
        }
        
    }
}
