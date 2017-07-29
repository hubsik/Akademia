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
    /// Logika interakcji dla klasy UserDataPage.xaml
    /// </summary>
    public partial class UserDataPage : Page
    {
        public UserDataPage()
        {
            InitializeComponent();
        }

        private void TextBoxDataUserPageName_GotFocus(object sender, RoutedEventArgs e)
        {
            TextBoxDataUserPageName.Text = string.Empty;
        }

        private void TextBoxDataUserPageSurname_GotFocus(object sender, RoutedEventArgs e)
        {
            TextBoxDataUserPageSurname.Text = string.Empty;
        }

        private void TextBoxDataUserPageNumber_GotFocus(object sender, RoutedEventArgs e)
        {
            TextBoxDataUserPageNumber.Text = string.Empty;
        }

        private void TextBoxDataUserPageMail_GotFocus(object sender, RoutedEventArgs e)
        {
            TextBoxDataUserPageMail.Text = string.Empty;
        }

        private void TextBoxDataUserPageAdress_GotFocus(object sender, RoutedEventArgs e)
        {
            TextBoxDataUserPageAdress.Text = string.Empty;
        }
    }
}
