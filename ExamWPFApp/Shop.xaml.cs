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
    /// Логика взаимодействия для Shop.xaml
    /// </summary>
    public partial class Shop : Window
    {
        public Shop()
        {
            InitializeComponent();
            ProductList.Items.Clear();
            BalanceTB.Text = ActiveUser.Customer.Account.ToString();
            for(int i = 0; i < Product.Products.Count; i++)
            {
                ProductList.Items.Add(Product.Products[i]);
            }
        }

        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            BalanceAdd balanceAdd = new BalanceAdd();
            if(balanceAdd.ShowDialog().Value)
            {
                BalanceTB.Text = ActiveUser.Customer.Account.ToString();
            }
        }

        private void ProductList_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            BasketList.Items.Add(ProductList.SelectedItem);
            ProductSumTB.Text = "0";
            foreach (Product item in BasketList.Items)
            {
                ProductSumTB.Text = (int.Parse(ProductSumTB.Text) + item.Cost).ToString();
            }
        }

        private void BasketBtn_Click(object sender, RoutedEventArgs e)
        {
            ShopTC.SelectedIndex = 1;
            ProductSumTB.Text = "0";
            foreach (Product item in BasketList.Items)
            {
                ProductSumTB.Text = (int.Parse(ProductSumTB.Text) + item.Cost).ToString();
            }
        }

        private void ProductsBtn_Click(object sender, RoutedEventArgs e)
        {
            ShopTC.SelectedIndex = 0;
        }

        private void TabItem_GotFocus(object sender, RoutedEventArgs e)
        {
            ProductSumTB.Text = "0";
            foreach (Product item in BasketList.Items)
            {
                ProductSumTB.Text = (int.Parse(ProductSumTB.Text) + item.Cost).ToString();
            }
        }

        private void PurchaseBtn_Click(object sender, RoutedEventArgs e)
        {
            if(int.Parse(ProductSumTB.Text) > ActiveUser.Customer.Account)
            {
                MessageBox.Show("Недостаточно средств");
                return;
            }
            List<Product> products = new List<Product>();
            foreach (Product item in BasketList.Items)
            {
                products.Add(item);
            }
            PurchaseHistory purchaseHistory = new PurchaseHistory(ActiveUser.Customer.Name, products, int.Parse(ProductSumTB.Text), DateTime.Now);
            ActiveUser.Customer.Account -= int.Parse(ProductSumTB.Text);
            MongoExamples.ReplaceByName(ActiveUser.Customer.Name, ActiveUser.Customer);
            MongoExamples.AddPurchaseHistoryToDB(purchaseHistory);
            MessageBox.Show("Покупка совершена успешно");
        }
    }
}
