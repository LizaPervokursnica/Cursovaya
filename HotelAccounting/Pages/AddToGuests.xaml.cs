using HotelAccounting.Classes;
using HotelAccounting.DataAccess;
using System;
using System.Linq;
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
            if (AddBtn.Content == "Добавить")
            {
                using (HotelDbContext appContext = new HotelDbContext())
                {

                    appContext.Guests.Add(new Guest
                    {
                        Name = NameTextBox.TxtBox.Text,
                        Phone = PhoneTextBox.TxtBox.Text,
                        Sex = "Мужской",
                        Photo = PhotoTextBox.TxtBox.Text
                    });

                    appContext.SaveChanges();
                }
            }
            else if(AddBtn.Content == "Сохранить")
            {
                using (HotelDbContext appContext = new HotelDbContext())
                {
                    var guest = appContext.Guests.Where(x => x.Id == (int)GID.Content).FirstOrDefault();
                    guest.Name = NameTextBox.TxtBox.Text;
                    guest.Phone = PhoneTextBox.TxtBox.Text;
                    guest.Photo = PhotoTextBox.TxtBox.Text;
                    if (Male.IsChecked == true) guest.Sex = "♂";
                    else if (Female.IsChecked == true) guest.Sex = "♀";
                    else guest.Sex = " ";
                    appContext.SaveChanges();
                }
            }
        }
    }
}
