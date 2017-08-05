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
    /// Logika interakcji dla klasy RestaurantChooser.xaml
    /// </summary>
    public partial class RestaurantChooser : Page
    {
        public List<Restaurant> ListOfRestaurantsForSelectedCity = new List<Restaurant>();
        Frame FrameForPages2 = new Frame();
        public Restaurant SelectedRestaurant { get; set; }
        public RestaurantChooser(List<Restaurant> listOfRestaurantsForSelectedCity, Frame frameForPages2)
        {
            InitializeComponent();
            ListOfRestaurantsForSelectedCity = listOfRestaurantsForSelectedCity;
            FrameForPages2 = frameForPages2;
            ListBoxRestaurants.Items.Clear();

            foreach (Restaurant restaurant in listOfRestaurantsForSelectedCity)
            {
                ListBoxRestaurants.Items.Add((string)restaurant.Name);
            }
        }

        private void ListBoxRestaurants_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            var item = ItemsControl.ContainerFromElement(ListBoxRestaurants, e.OriginalSource as DependencyObject) as ListBoxItem;
            if (item != null)
            {
                try
                {
                    foreach (Restaurant restaurant in ListOfRestaurantsForSelectedCity)
                    {
                        if (restaurant.Name == item.Content.ToString())
                        {
                            SelectedRestaurant = restaurant;
                        }

                    }
                    UserDataPage userDataPage = new UserDataPage(SelectedRestaurant);
                    NavigationService.Navigate(userDataPage);
                    FrameForPages2.NavigationService.Navigate(new ComponentChooser(SelectedRestaurant, userDataPage));
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Restaurant chooser " +ex.Message);
                }
                    
            }
        }
    }
}
