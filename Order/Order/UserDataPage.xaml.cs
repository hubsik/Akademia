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
        public Restaurant SelectedRestaurant { get; set; }
        public UserDataPage(Restaurant selectedRestaurant)
        {
            InitializeComponent();
            SelectedRestaurant = selectedRestaurant;

            if (SelectedRestaurant.Delivery == false)
            {
                TextBoxDataUserPageAdress.Text = "Brak mozliwosci dowozu";
                TextBoxDataUserPageAdress.IsEnabled = false;
            }

            
        }

       

        public bool TextBoxesAreNotEmpty()
        {
            if (TextBoxDataUserPageName.Text != string.Empty && TextBoxDataUserPageSurname.Text != string.Empty && TextBoxDataUserPageNumber.Text != string.Empty && TextBoxDataUserPageMail.Text != string.Empty && TextBoxDataUserPageAdress.Text != string.Empty)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
