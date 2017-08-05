using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Order
{
    public class Meal
    {
        public List<Product> Meat = new List<Product>();
        public List<Product> Vegetables = new List<Product>();
        public List<Product> Other = new List<Product>();
        public string Type { get; set; }
        public string Size { get; set; }

        public Meal(List<Product> meat, List<Product> vegetables, List<Product> other, string type, string size)
        {
            this.Meat = meat;
            this.Vegetables = vegetables;
            this.Other = other;
            this.Type = type;
            this.Size = size;
        }

        public double PartialCost(string Size)
        {
            double partialCost = 0;
            if (Size == "XL")
            {
                switch (Type)
                {
                    case "Kebab":
                        partialCost =  12;
                        break;
                    case "Burger":
                        partialCost = 10;
                        break;
                    case "Sushi":
                        partialCost = 20;
                        break;
                    case "Pizza":
                        partialCost = 14;
                        break;
                    default:
                        partialCost = 0;
                        break;
                }
            }
            if (Size == "L")
            {
                switch (Type)
                {
                    case "Kebab":
                        partialCost = 9;
                        break;
                    case "Burger":
                        partialCost = 7;
                        break;
                    case "Sushi":
                        partialCost = 17;
                        break;
                    case "Pizza":
                        partialCost = 12;
                        break;
                    default:
                        partialCost = 0;
                        break;
                }
            }
            if (Size == "S")
            {
                switch (Type)
                {
                    case "Kebab":
                        partialCost = 6;
                        break;
                    case "Burger":
                        partialCost = 8;
                        break;
                    case "Sushi":
                        partialCost = 15;
                        break;
                    case "Pizza":
                        partialCost = 10;
                        break;
                    default:
                        partialCost = 0;
                        break;
                }
            }

            return partialCost;
        }

        public double Cost()
        {
            double cost = 0;
            foreach (Product product in Meat)
            {
                cost += product.Cost;
            }
            foreach (Product product in Vegetables)
            {
                cost += product.Cost;
            }
            foreach (Product product in Other)
            {
                cost += product.Cost;
            }
            cost += PartialCost(Size);
            return cost;
        }
    }
}
