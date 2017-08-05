using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Order
{
    public class OrderForm
    {
        public string FullName { get; set; }
        public string TelephoneNumber { get; set; }
        public string Mail { get; set; }
        public string Address { get; set; }
        public string OrderNumber { get; set; }
        public Restaurant SelectedRestaurant { get; set; }
        public List<Meal> Meals = new List<Meal>();
        public DateTime TimeWhenOrdered { get; set; }
        public DateTime TimeWhenDelivered { get; set; }

        public OrderForm(string fullName, string telephoneNumber, string mail, string address, List<Meal> meals, DateTime timeWhenOrdered, DateTime timeWhenDelivered, Restaurant selectedRestaurant)
        {
            this.FullName = fullName;
            this.TelephoneNumber = telephoneNumber;
            this.Mail = mail;
            this.Address = address;
            this.Meals = meals;
            this.TimeWhenOrdered = timeWhenOrdered;
            this.TimeWhenDelivered = timeWhenDelivered;
            this.SelectedRestaurant = selectedRestaurant;

            OrderNumber = OrderNumberBuild();
        }

        public double TotalCost()
        {
            double totalCost = 0;
            foreach (Meal meal in Meals)
            {
                totalCost += meal.Cost();
            }
            return totalCost;
        }

        public string OrderNumberBuild()
        {
            string orderNumber = string.Empty;
            orderNumber = SelectedRestaurant.City + SelectedRestaurant.Name + TimeWhenOrdered.ToString("dd_MM_yyyy-hh_mm_ss");
            return orderNumber;

        }
    }
}
