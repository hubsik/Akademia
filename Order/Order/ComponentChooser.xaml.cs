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
using System.Globalization;

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
        public Frame FrameForPages = new Frame();
        public Frame FrameForPages2 = new Frame();
        UserDataPage UserDataPage; 


        //////////////////

        List<Product> Meat = new List<Product>();
        List<Product> Vegetables = new List<Product>();
        List<Product> Other = new List<Product>();
        public string Type { get; set; }
        public string Size { get; set; }
        Meal NewMeal;

        public ComponentChooser(Restaurant selectedRestaurant, UserDataPage userDataPage, Frame frameForPages, Frame frameForPages2)
        {
            InitializeComponent();

            SelectedRestaurant = selectedRestaurant;
            FrameForPages = frameForPages;
            FrameForPages2 = frameForPages2;
            NewMeal = new Meal(Meat, Vegetables, Other, SelectedRestaurant.Type, Size);
            UserDataPage = userDataPage;
            ListOut();

            ListBoxSize.Items.Add("XL");
            ListBoxSize.Items.Add("L");
            ListBoxSize.Items.Add("S");

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
                    switch (product.Type)
                    {
                        case "mieso":
                            NewMeal.Meat.Add(product);
                            break;
                        case "warzywo":
                            NewMeal.Vegetables.Add(product);
                            break;
                        case "inne":
                            NewMeal.Other.Add(product);
                            break;
                        default:
                            break;
                    }
                    ButtonOrder.Content = "Zamow(" + NewMeal.Cost().ToString() + " zl)";

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
            NewMeal.Size = ListBoxSize.SelectedItem.ToString();
            Cost += NewMeal.PartialCost(NewMeal.Size);
            ListBoxSize.IsEnabled = false;
            ButtonOrder.Content = "Zamow(" + NewMeal.Cost().ToString() + " zl)";
        }

        public bool ButtonOrderAvailable()
        {
            if (UserDataPage.TextBoxesAreNotEmpty() && ListBoxSize.IsEnabled == false)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private void ButtonOrder_Click(object sender, RoutedEventArgs e)
        {
            if (ButtonOrderAvailable())
            {
                string FullName = UserDataPage.TextBoxDataUserPageName.Text + " " + UserDataPage.TextBoxDataUserPageSurname.Text;
                string TelephoneNumber = UserDataPage.TextBoxDataUserPageNumber.Text;
                string Mail = UserDataPage.TextBoxDataUserPageMail.Text;
                string Address = UserDataPage.TextBoxDataUserPageAdress.Text;
                List<Meal> Meals = new List<Meal>();
                Meals.Add(NewMeal);
                DateTime TimeWhenOrdered = DateTime.Now;
                DateTime TimeWhenDelivered = DateTime.Now;
                
                if (Meals.Count > 3)
                {
                    TimeWhenDelivered = TimeWhenDelivered.AddHours(2);
                }
                else
                {
                    TimeWhenDelivered = TimeWhenDelivered.AddHours(1);
                }

                NavigationService.Navigate(null);
                
                UserDataPage.NavigationService.Navigate(new SummaryPage(new OrderForm(FullName, TelephoneNumber, Mail, Address, Meals, TimeWhenOrdered, TimeWhenDelivered, SelectedRestaurant), FrameForPages, FrameForPages2));
                
            }
            else
            {
                MessageBox.Show("Nie wszystkie pola zostaly wypelnione");
            }
        }

        private void ButtonPreviousPage_Click(object sender, RoutedEventArgs e)
        {
            if (this.NavigationService.CanGoBack)
            {
                this.NavigationService.GoBack();
            }

            if (UserDataPage.NavigationService.CanGoBack)
            {
                UserDataPage.NavigationService.GoBack();
            }
        }
    }
}
