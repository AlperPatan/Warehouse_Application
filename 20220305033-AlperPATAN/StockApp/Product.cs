using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockApp
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Quantity { get; set; }
        public string Brand { get; set; }

        public Product(int id, string name, int quantity, string brand)
        {
            Id = id;
            Name = name;
            Quantity = quantity;
            Brand = brand;
        }
    }
}
