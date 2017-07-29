﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Order
{
     public class Restaurant
     {
        
        public string City { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public bool Delivery { get; set; }
        public List<Product> Products = new List<Product>();
        public List<OrderForm> OrderForms = new List<OrderForm>();
        //Potrzebny wykaz dostępnych dań w danej Restauracji

        public Restaurant(string city, string name, string type, bool delivery, List<Product> products)
        {
            this.City = city;
            this.Name = name;
            this.Type = type;
            this.Delivery = delivery;
            this.Products = products;
        }
     }
}