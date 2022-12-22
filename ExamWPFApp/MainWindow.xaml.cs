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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Registration_Click(object sender, RoutedEventArgs e)
        {
            if (FName.Text != String.Empty && LName.Text != String.Empty && 
                Password.Password != String.Empty && RepeatPasswod.Password != String.Empty &&
                BirthDate.Text != String.Empty && Login.Text != String.Empty)
            {
                if (RepeatPasswod.Password  == Password.Password)
                {
                    try
                    { 
                        User user = new User(FName.Text, LName.Text, Login.Text, Password.Password, DateOnly.Parse(BirthDate.Text));
                        UserMongoDB.AddUnitTodataBase(user);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
                else MessageBox.Show("Passwords must match");
            }
            else MessageBox.Show("All fields must be filled");
        }
    }
}
