using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamWPFApp.Data
{
    public class PurchaseHistory
    {
        public string CustomerName { get; set; }
        public List<Product> Products  = new List<Product>();
        public int Sum { get; set; }
        public DateTime Date { get; set; }
        public PurchaseHistory(string customerName, List<Product> products, int sum, DateTime date)
        {
            CustomerName = customerName;
            Products = products;
            Sum = sum;
            Date = date;
        }
    }
}
