using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Order
{
    public class OrderForm
    {
        public List<Meal> Meals = new List<Meal>();
        public DateTime TimeWhenOrdered { get; set; }
        public DateTime TimeWhenDelivered { get; set; }
        public double _totalCost { get; set; }

        OrderForm(List<Meal> meals, DateTime timeWhenOrdered, DateTime timeWhenDelivered)
        {
            this.Meals = meals;
            this.TimeWhenOrdered = timeWhenOrdered;
            this.TimeWhenDelivered = timeWhenOrdered;
        }

        public double TotalCost
        {
            get
            {
                return _totalCost;
            }
            set
            {
                //Cena każdego posiłku, do zrobienia póxniej jak będę miał ogólny zarys jak to ma wyglądać 
                _totalCost = value;
            }
        }
    }
}
