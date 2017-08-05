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
    /// Logika interakcji dla klasy SummaryPage.xaml
    /// </summary>
    public partial class SummaryPage : Page
    {
        public OrderForm OrderForm { get; set; }
        public SummaryPage(OrderForm orderForm)
        {
            InitializeComponent();
            OrderForm = orderForm;

            LabelOrderNumber.Content = "Numer Zamowienia: " + OrderForm.OrderNumber;
            LabelFullName.Content = "Zamawiajacy: " + OrderForm.FullName;
            LabelTelephoneNumber.Content = "Numer Telefonu " + OrderForm.TelephoneNumber;
            LabelMail.Content = "Mail: " + OrderForm.Mail;
            LabelAddress.Content = "Adres: " + OrderForm.Address;
            LabelLink.Content = "brak";
            LabelType.Content = "Jedzenie: " + OrderForm.Meals[0].Type;
            LabelComponents.Content = "Skladniki: ";
            foreach (Product product in OrderForm.Meals[0].Meat)
            {
                LabelComponents2.Content = LabelComponents2.Content  + product.Name + ", ";
            }
            foreach (Product product in OrderForm.Meals[0].Vegetables)
            {
                LabelComponents2.Content = LabelComponents2.Content  + product.Name + ", ";
            }
            foreach (Product product in OrderForm.Meals[0].Other)
            {
                LabelComponents2.Content = LabelComponents2.Content  + product.Name + " ";
            }
            LabelTimeWhenOrdered.Content = "Zamowiono: " + OrderForm.TimeWhenOrdered;
            LabelTimeWhenDelivered.Content = "Planowany czas dostawy: " + OrderForm.TimeWhenDelivered;
        }

        private void ButtonEnd_Click(object sender, RoutedEventArgs e)
        {
            using (StreamWriter writer = new StreamWriter(OrderForm.OrderNumber+".txt"))
            {
                writer.WriteLine("Numer Zamowienia: " + OrderForm.OrderNumber);
                writer.WriteLine("Zamawiajacy: " + OrderForm.FullName);
                writer.WriteLine("Numer Telefonu " + OrderForm.TelephoneNumber);
                writer.WriteLine("Mail: " + OrderForm.Mail);
                writer.WriteLine("Adres: " + OrderForm.Address);
                writer.WriteLine("brak");
                writer.WriteLine("Jedzenie: " + OrderForm.Meals[0].Type);
                writer.WriteLine("Skladniki: "+ LabelComponents2.Content);
                writer.WriteLine("Zamowiono: " + OrderForm.TimeWhenOrdered);
                writer.WriteLine("Planowany czas dostawy: " + OrderForm.TimeWhenDelivered);
                writer.WriteLine("Uwagi: ");
                writer.WriteLine(TextBoxNote.Text);

     
            }
        }
    }
}
