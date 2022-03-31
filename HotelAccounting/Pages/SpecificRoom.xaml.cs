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
        public string PhotoURL { get; set; }
        public SpecificRoom()
        {
            InitializeComponent();
            DataContext = this;
            HotelDbContext dbContext = new HotelDbContext();
            GComboBox.ItemsSource = dbContext.Guests.ToList();

        }

        private void GoBack(object sender, RoutedEventArgs e) =>
            NavigationService.Navigate(new Uri("Pages/HomePage.xaml", UriKind.RelativeOrAbsolute));
    }
}
