using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamWPFApp
{
    public class PurchaseData
    {
        public PurchaseData(string nameCustomer, List<Product> products, int cost)
        {
            NameCustomer = nameCustomer;
            this.products = products;
            Cost = cost;
            Created = DateTime.Now;
        }

        public string NameCustomer { get; set; }
        public List<Product> products { get; set; }
        public int Cost { get; set; }
        public DateTime Created { get; set; }


    }
}
