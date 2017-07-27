using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Order
{
    public abstract class Meal
    {
        public string Size { get; set; }
        public abstract double Cost();
    }
}
