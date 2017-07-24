using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Order
{
    class Pizza : Meal
    {
        public List<string> Toppings;
        public string TypeOfPizzaDough { get; set; }
        Pizza(string size, string typeOfPizzaDough, List<string> toppings)
        {
            this.Size = size;
            this.TypeOfPizzaDough = typeOfPizzaDough;
            this.Toppings = toppings;
        }

        public override double Cost()
        {
            return 30;
        }
    }
}
