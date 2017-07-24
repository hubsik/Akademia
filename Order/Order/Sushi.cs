using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Order
{
    class Sushi : Meal
    {
        public string TypeOfSushi { get; set; }
        Sushi(string size, string typeOfSushi)
        {
            this.Size = size;
            this.TypeOfSushi = typeOfSushi;
        }

        public override double Cost()
        {
            return 60;
        }
    }
}
