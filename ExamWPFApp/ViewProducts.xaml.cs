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
    /// Логика взаимодействия для ViewProducts.xaml
    /// </summary>
    public partial class ViewProducts : Window
    {
        User CurrenUser;
        public ViewProducts(User user)
        {
            InitializeComponent();
            Product Apple = new Product("Apple", 12);
            Product Plum = new Product("Plum", 8);
            Product Nail = new Product("Nail", 12);
            Product Hammer = new Product("Hammer", 8);
            Products.Items.Add(Apple);
            Products.Items.Add(Plum);
            Products.Items.Add(Nail);
            Products.Items.Add(Hammer);
            CurrenUser = user;
            CashAccount.Text = $"{CurrenUser.CashAccount}";
            UnitsInventoryUpdate();
        }

        private void ViewProducts_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            var item = ((sender as ListView).SelectedItem as Product);
            if (item != null) CurrenUser.ShoppingBasket.Add(item);
            UserMongoDB.ReplaceUser(CurrenUser.Login, CurrenUser);
            UnitsInventoryUpdate();
        }

        private void UnitsInventoryUpdate()
        {
            ShoppingBasket.Items.Clear();
            if (CurrenUser.ShoppingBasket != null)
            {
                foreach (var i in CurrenUser.ShoppingBasket)
                {
                    ShoppingBasket.Items.Add(i);
                }
            }
        }

        private void Pay_Click(object sender, RoutedEventArgs e)
        {
            int purchasesAmount = 0;
            if (CurrenUser.ShoppingBasket != null)
            {
                foreach (var i in CurrenUser.ShoppingBasket)
                {
                    purchasesAmount += i.Cost;
                }
                if (purchasesAmount > CurrenUser.CashAccount)
                {
                    MessageBox.Show("Not enough funds");
                }
                else 
                {
                    CurrenUser.CashAccount -= purchasesAmount;
                    UserMongoDB.AddPurchaseDataTodataBase(CurrenUser.FirstName, CurrenUser.ShoppingBasket, purchasesAmount);
                    CurrenUser.ShoppingBasket = new List<Product>();
                    UserMongoDB.ReplaceUser(CurrenUser.Login, CurrenUser);
                }
            }
        }

        private void PurchaseData_Click(object sender, RoutedEventArgs e)
        {
            var newData = UserMongoDB.FindAllPurchaseData();
            
        }
    }
}
