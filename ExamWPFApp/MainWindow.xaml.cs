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
using ExamWPFApp.Data;

namespace ExamWPFApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void RegistrationBtn_Click(object sender, RoutedEventArgs e)
        {
            if(NameTB.Text == "" || SurnameTB.Text == "" || BirthDateTB.Text == "" || LoginTB.Text == "" || PasswordTB.Password == "")
            {
                MessageBox.Show("Не все поля заполнены");
                return;
            }
            if(PasswordTB.Password != PasswrodConfirmationTB.Password)
            {
                MessageBox.Show("Неправильный пароль");
                return;
            }    
            string[] date = new string[0];
            if (BirthDateTB.Text.Split(' ').Length == 3)
            {
                date = BirthDateTB.Text.Split(' ');
            }
            else if(BirthDateTB.Text.Split('.').Length == 3)
            {
                date = BirthDateTB.Text.Split('.');
            }
            DateTime birthDate;
            try
            {
                birthDate = new DateTime(int.Parse(date[2]), int.Parse(date[1]), int.Parse(date[0]));
            }
            catch
            {
                MessageBox.Show("Введена неправильная дата");
                return;
            }
            Customer newCustomer = new Customer(NameTB.Text, SurnameTB.Text, birthDate, LoginTB.Text, PasswordTB.Password);
            MongoExamples.AddToDB(newCustomer);
            MessageBox.Show("Регистрация прошла успешно");
            ActiveUser.Customer = newCustomer;
            Shop shop = new Shop();
            shop.Show();
            this.Close();
        }

        private void AuthorizationBtn_Click(object sender, RoutedEventArgs e)
        {
            AuthorizationWindow authorizationWindow = new AuthorizationWindow();
            authorizationWindow.Show();
            this.Close();
        }
    }
}
