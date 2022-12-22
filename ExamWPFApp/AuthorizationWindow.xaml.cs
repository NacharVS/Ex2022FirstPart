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
using System.Windows.Shapes;
using ExamWPFApp.Data;

namespace ExamWPFApp
{
    /// <summary>
    /// Логика взаимодействия для AuthorizationWindow.xaml
    /// </summary>
    public partial class AuthorizationWindow : Window
    {
        public AuthorizationWindow()
        {
            InitializeComponent();
        }

        private void LoginBtn_Click(object sender, RoutedEventArgs e)
        {
            if(LoginTB.Text == "" || PasswordTB.Password == "")
            {
                MessageBox.Show("Не все поля заполнены");
                return;
            }
            if(MongoExamples.Find(LoginTB.Text) != null)
            {
                if (MongoExamples.Find(LoginTB.Text).Password == PasswordTB.Password)
                {
                    MessageBox.Show("Авторизация успешна");
                    ActiveUser.Customer = MongoExamples.Find(LoginTB.Text);
                    Shop shop = new Shop();
                    shop.Show();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Пароль неверный");
                    return;
                }
            }
            else
            {
                MessageBox.Show("Логин не найден");
                return;
            }
        }

        private void RegistrationBtn_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }
    }
}
