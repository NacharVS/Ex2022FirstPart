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
    /// Логика взаимодействия для BalanceAdd.xaml
    /// </summary>
    public partial class BalanceAdd : Window
    {
        public BalanceAdd()
        {
            InitializeComponent();
        }

        private void AddToBalance_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ActiveUser.Customer.Account = int.Parse(BalanceTB.Text);
                MongoExamples.ReplaceByName(ActiveUser.Customer.Name, ActiveUser.Customer);
                this.DialogResult = true;
            }
            catch
            {
                MessageBox.Show("Неправильный формат");
                return;
            }
        }
    }
}
