using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Order
{
    class Kebab : Meal
    {
        public string Sauce { get; set; }
        public string Meat { get; set; }
        public bool Vegetables { get; set; }
        Kebab(string size, string sauce, string meat, bool vegetables)
        {
            this.Size = size;
            this.Sauce = sauce;
            this.Meat = meat;
            this.Vegetables = vegetables;
        }

        public override double Cost()
        {
            return 10;
        }
    }
}
