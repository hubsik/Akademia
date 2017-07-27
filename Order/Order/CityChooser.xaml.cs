using System;
using System.Collections.Generic;
using System.IO;
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
    /// Logika interakcji dla klasy CityChooser.xaml
    /// </summary>
    public partial class CityChooser : Page
    {
        public List<Restaurant> ListOfRestaurants = new List<Restaurant>();
        public List<Restaurant> ListOfRestaurantsForSelectedCity = new List<Restaurant>();
        public string city { get; set; }
        public string name { get; set; }
        public string type { get; set; }
        public bool delivery { get; set; }
        public List<Product> products = new List<Product>();
        Frame FrameForPages2 = new Frame();
        Frame FrameForPages = new Frame();
        public CityChooser(Frame frameForPages, Frame frameForPages2)
        {
            InitializeComponent();
            LoadRestaurants();
            FrameForPages = frameForPages;
            FrameForPages2 = frameForPages2;
            


        }
        private void TextBoxCity_GotFocus(object sender, RoutedEventArgs e)
        {
            TextBoxCity.Text = "";
        }

        private void TextBoxCity_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                for (int i = 0 ; i < ListOfRestaurants.Count ; i++)
                {
                    if (ListOfRestaurants[i].City == TextBoxCity.Text)
                    {
                        ListOfRestaurantsForSelectedCity.Add(ListOfRestaurants[i]);
                    }
                }
                if (ListOfRestaurantsForSelectedCity.Count == 0)
                {
                    LabelCity.Content = "Nie mamy w bazie restauracji dla Twojego miasta.";
                }
                else
                {
                    this.NavigationService.Navigate(new RestaurantChooser(ListOfRestaurantsForSelectedCity));
                    FrameForPages2.NavigationService.Navigate(new IngredientsChooser(ListOfRestaurantsForSelectedCity, FrameForPages) );
                }
            }
        }
        public void LoadRestaurants()
        {
            try
            {   // Open the text file using a stream reader.
                using (StreamReader sr = new StreamReader("Restaurants.txt"))
                {

                    while (!sr.EndOfStream)
                    {
                        city = sr.ReadLine();
                        name = sr.ReadLine();
                        type = sr.ReadLine();
                        delivery = Convert.ToBoolean(sr.ReadLine());
                        sr.ReadLine();
                        string Line;
                        while ((Line = sr.ReadLine()) != "//////////")
                        {
                            string[] Words = Line.Split(' ');
                            products.Add(new Product(Words[0], Words[1], Convert.ToDouble(Words[2])));
                        }
                        ListOfRestaurants.Add(new Restaurant(city, name, type, delivery, products));
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("The file could not be read: " + e.Message);
            }
        }
    }
}
