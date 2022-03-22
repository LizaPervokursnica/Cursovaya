using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace HotelAccounting.Pages
{
    /// <summary>
    /// Interaction logic for GuestPage.xaml
    /// </summary>
    public partial class GuestPage : Page
    {
       
        public GuestPage()
        {
            InitializeComponent();
            try 
            {
                ApplicationContext context = new ApplicationContext();
                ListV.ItemsSource = context.Guests.ToArray(); 
            }
            catch { MessageBox.Show("Ошибка подключеия к базе данных", "Ошибка!", MessageBoxButton.OK); }
        }
    }
}
