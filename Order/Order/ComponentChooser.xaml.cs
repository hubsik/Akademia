using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Order
{
    /// <summary>
    /// Logika interakcji dla klasy ComponentChooser.xaml
    /// </summary>s
    public partial class ComponentChooser : Page
    {
        public Restaurant SelectedRestaurant { get; set; }
        public OrderForm orderForm { get; set; }
        public double Cost { get; set; }


        //////////////////
        public string Sauce { get; set; }
        public string Meat { get; set; }
        public bool Vegetables { get; set; }
        public string Size { get; set; }
        public bool Cheese { get; set; }
        public string TypeOfSushi { get; set; }
        public List<Product> ListVegetables = new List<Product>();
        public List<Product> Toppings = new List<Product>();

        public ComponentChooser(Restaurant selectedRestaurant)
        {
            InitializeComponent();

            //SelectedRestaurant = selectedRestaurant;
            //switch (SelectedRestaurant.Type)
            //{
            //    case "Kebab":
            //        Meal NewMeal = new Kebab(Size, Sauce, Meat, Vegetables);
            //        break;
            //    case "Burger":
            //        Meal Burger = new Burger(Size, Sauce, Meat, Cheese, ListVegetables);
            //        break;
            //    case "Sushi":
            //        Meal Sushi = new Sushi(Size, TypeOfSushi);
            //        break;
            //    case "Pizza":
            //        Meal Pizza = new Pizza(Size, Toppings);
            //        break;
            //    default:
            //        break;
            //}
            ListOut();

            ListBoxSize.Items.Add("XL - 13");
            ListBoxSize.Items.Add("L - 10");
            ListBoxSize.Items.Add("S - 8");

        }

        private void ListBoxComponents_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            var item = ItemsControl.ContainerFromElement(ListBoxComponents, e.OriginalSource as DependencyObject) as ListBoxItem;
            if (item != null)
            {
                DeleteProduct(item.Content.ToString());
                ListOut();
            }
        }

        public void DeleteProduct(string name)
        {
            ListBoxComponents.Items.Clear();
            ListBoxComponentsCost.Items.Clear();
            Product ProductToDelete = null;
            foreach (Product product in SelectedRestaurant.Products)
            {
                if (product.Name == name)
                {
                    Cost += product.Cost;
                    ButtonOrder.Content = "Zamow(" + Cost.ToString() + " zl)";

                    ProductToDelete = product;
                }
            }
            SelectedRestaurant.Products.Remove(ProductToDelete);
        }

        public void ListOut()
        {
            foreach (Product product in SelectedRestaurant.Products)
            {
                ListBoxComponents.Items.Add(product.Name);
                ListBoxComponentsCost.Items.Add(product.Cost + " zl");
            }
        }

        private void ListBoxSize_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            MessageBox.Show(ListBoxSize.SelectedItem.ToString());
        }

    }
}
