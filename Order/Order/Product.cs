using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Order
{
    public class Product
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public double Cost { get; set; }

        public Product(string name, string type, double cost)
        {
            this.Name = name;
            this.Type = type;
            this.Cost = cost;
        }
    }
}
