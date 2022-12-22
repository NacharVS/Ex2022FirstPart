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

namespace ExamWPFApp
{
    /// <summary>
    /// Логика взаимодействия для Authorization.xaml
    /// </summary>
    public partial class Authorization : Window
    {
        public Authorization()
        {
            InitializeComponent();
        }

        private void Authorization_Click(object sender, RoutedEventArgs e)
        {
            if (Password.Password != String.Empty && Login.Text != String.Empty)
            {
                try
                {
                    User user = UserMongoDB.FindUser(Login.Text);
                    if (user == null || user.Password != Password.Password)
                    {
                        MessageBox.Show("Incorrect login or password");
                    }
                    else 
                    {
                        ViewProducts viewProducts = new ViewProducts(user);
                        viewProducts.Show();
                        this.Close();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else MessageBox.Show("All fields must be filled");
        }

        private void Registration_Click(object sender, RoutedEventArgs e)
        {
            MainWindow Registration = new MainWindow();
            Registration.Show();
            this.Close();
        }
    }
}

