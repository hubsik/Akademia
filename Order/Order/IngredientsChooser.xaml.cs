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
    /// Logika interakcji dla klasy IngredientsChooser.xaml
    /// </summary>
    public partial class IngredientsChooser : Page
    {
        public List<Restaurant> ListOfRestaurantsForSelectedCity = new List<Restaurant>();
        public List<Restaurant> ListOfRestaurantsForSelectedCityAfterIngredients = new List<Restaurant>();
        public List<string> SelectedTypeOfIngredients = new List<string>();
        public Frame FrameForPages = new Frame();
        public IngredientsChooser(List<Restaurant> listOfRestaurantsForSelectedCity, Frame frameForPages)
        {
            InitializeComponent();
            ListOfRestaurantsForSelectedCity = listOfRestaurantsForSelectedCity;
            FrameForPages = frameForPages;
        }

        private void CheckBoxPizza_Checked(object sender, RoutedEventArgs e)
        {
            SelectedTypeOfIngredients.Add("Pizza");
            MakeRestaurantChooser();
        }

        private void CheckBoxSushi_Checked(object sender, RoutedEventArgs e)
        {
            SelectedTypeOfIngredients.Add("Sushi");
            MakeRestaurantChooser();
        }

        private void CheckBoxKebab_Checked(object sender, RoutedEventArgs e)
        {
            SelectedTypeOfIngredients.Add("Kebab");
            MakeRestaurantChooser();
        }

        private void CheckBoxBurger_Checked(object sender, RoutedEventArgs e)
        {
            SelectedTypeOfIngredients.Add("Burger");
            MakeRestaurantChooser();
        }

        private void CheckBoxOther_Checked(object sender, RoutedEventArgs e)
        {
            SelectedTypeOfIngredients.Add("Inne");
            MakeRestaurantChooser();
        }

        /// //////////////////////////////////////////////////////////////

        private void CheckBoxPizza_Unchecked(object sender, RoutedEventArgs e)
        {
            SelectedTypeOfIngredients.RemoveAll(i => i == "Pizza");
            MakeRestaurantChooser();
        }

        private void CheckBoxSushi_Unchecked(object sender, RoutedEventArgs e)
        {
            SelectedTypeOfIngredients.RemoveAll(i => i == "Sushi");
            MakeRestaurantChooser();
        }

        private void CheckBoxKebab_Unchecked(object sender, RoutedEventArgs e)
        {
            SelectedTypeOfIngredients.RemoveAll(i => i == "Kebab");
            MakeRestaurantChooser();
        }

        private void CheckBoxBurger_Unchecked(object sender, RoutedEventArgs e)
        {
            SelectedTypeOfIngredients.RemoveAll(i => i == "Burger");
            MakeRestaurantChooser();
        }

        private void CheckBoxOther_Unchecked(object sender, RoutedEventArgs e)
        {
            SelectedTypeOfIngredients.RemoveAll(i => i == "Inne");
            MakeRestaurantChooser();
        }

        public void MakeRestaurantChooser()
        {
            ListOfRestaurantsForSelectedCityAfterIngredients.Clear();
            foreach (string type in SelectedTypeOfIngredients)
            {
                foreach (Restaurant restaurant in ListOfRestaurantsForSelectedCity)
                {
                    if (restaurant.Type == type)
                    {
                        ListOfRestaurantsForSelectedCityAfterIngredients.Add(restaurant);
                    }
                }
            }
            FrameForPages.NavigationService.Navigate(new RestaurantChooser(ListOfRestaurantsForSelectedCityAfterIngredients));
        }
    }
}
