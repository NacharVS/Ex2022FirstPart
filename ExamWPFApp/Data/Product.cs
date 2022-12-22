using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamWPFApp.Data
{
    public class Product
    {
        public string Name { get; set; }
        public int Cost { get; set; }

        public static Dictionary<int, Product> Products = new Dictionary<int, Product>()
        {
            { 0, new Product("Vegetable", 100) },
            { 1, new Product("Water", 20) },
            { 2, new Product("AAA", 1000) },
        };

        public Product(string name, int cost)
        {
            Name = name;
            Cost = cost;
        }
    }
}
