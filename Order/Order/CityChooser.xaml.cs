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
    /// Logika interakcji dla klasy CityChooser.xaml
    /// </summary>
    public partial class CityChooser : Page
    {
        public CityChooser()
        {
            InitializeComponent();
        }
        private void TextBoxCity_GotFocus(object sender, RoutedEventArgs e)
        {
            TextBoxCity.Text = "";
        }

        private void TextBoxCity_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                MessageBox.Show("Miasto to " + TextBoxCity.Text);
            }
        }
    }
}
