using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Order
{
    class Burger : Meal
    {
        public string Sauce { get; set; }
        public string Meat { get; set; }
        public string TypeOfRoll { get; set; }  
        public bool Cheese { get; set; }
        public List<Product> Vegetables = new List<Product>();

        Burger(string size, string sauce, string meat, string typeOfRoll, bool cheese, List<Product> vegetables)
        {
            this.Size = size;
            this.Sauce = sauce;
            this.Meat = meat;
            this.TypeOfRoll = typeOfRoll;
            this.Cheese = cheese;
            this.Vegetables = vegetables;
        }

        public override double Cost()
        {
            return 15;
        }
    }
}
