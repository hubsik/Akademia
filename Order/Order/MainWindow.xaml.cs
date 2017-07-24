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
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Restaurant> ListOfRestaurants = new List<Restaurant>();
        public string city { get; set; }
        public string name { get; set; }
        public string type { get; set; }
        public bool delivery { get; set; }
        public MainWindow()
        {
            InitializeComponent();
            FrameForPages.NavigationService.Navigate(new CityChooser());
            LoadRestaurants();       
        }
        public void LoadRestaurants()
        {
            try
            {   // Open the text file using a stream reader.
                using (StreamReader sr = new StreamReader("Restaurants.txt"))
                {

                    while (!sr.EndOfStream)
                    {
                        // Read the stream to a string, and write the string to the console.
                        city = sr.ReadLine();
                        name = sr.ReadLine();
                        type = sr.ReadLine();
                        delivery = Convert.ToBoolean(sr.ReadLine());
                        sr.ReadLine();
                        ListOfRestaurants.Add(new Restaurant(city, name, type, delivery));
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("The file could not be read:" + e.Message);
            }
        }
    }
}
