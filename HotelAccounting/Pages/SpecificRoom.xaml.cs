using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using HotelAccounting.DataAccess;
using HotelAccounting.Model;

namespace HotelAccounting.Pages
{
    /// <summary>
    /// Interaction logic for SpecificRoom.xaml
    /// </summary>
    public partial class SpecificRoom : Page
    {
        HotelDbContext dbContext = new HotelDbContext();
        public string PhotoURL { get; set; }
        public SpecificRoom()
        {
            InitializeComponent();
            DataContext = this;
            GComboBox.ItemsSource = dbContext.Guests.ToList();
        }

        private void GoBack(object sender, RoutedEventArgs e) =>
            NavigationService.Navigate(new Uri("Pages/HomePage.xaml", UriKind.RelativeOrAbsolute));

        private void CheckInOutRoom_Click(object sender, RoutedEventArgs e)
        {
            if(StatusChangeBtn.Content == "Вселить")
            {

            }
            else if(StatusChangeBtn.Content == "Выселить")
            {

            }
        }
    }
}
