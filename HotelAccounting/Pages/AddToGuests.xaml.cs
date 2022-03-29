using HotelAccounting.Classes;
using HotelAccounting.DataAccess;
using System;
using System.Windows;
using System.Windows.Controls;

namespace HotelAccounting.Pages
{
    /// <summary>
    /// Логика взаимодействия для AddToGuests.xaml
    /// </summary>
    public partial class AddToGuests : Page
    {
        public AddToGuests()
        {
            InitializeComponent();
        }

        private void GoBack(object sender, RoutedEventArgs e) =>
            NavigationService.Navigate(new Uri("Pages/GuestPage.xaml", UriKind.RelativeOrAbsolute));

        private void AddNewGuestToDb(object sender, RoutedEventArgs e)
        {
            using (HotelDbContext appContext = new HotelDbContext())
            {
             
                appContext.Guests.Add(new Guest
                {
                    Name = NameTextBox.TxtBox.Text,
                    Phone = PhoneTextBox.TxtBox.Text,
                    Sex = "Мужской"
                });

                appContext.SaveChanges();
            }
        }
    }
}
