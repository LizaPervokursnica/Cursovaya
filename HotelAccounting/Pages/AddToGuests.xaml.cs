using HotelAccounting.Classes;
using HotelAccounting.DataAccess;
using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace HotelAccounting.Pages;

/// <summary>
/// Логика взаимодействия для AddToGuests.xaml
/// </summary>
public partial class AddToGuests : Page
{
    public AddToGuests() => InitializeComponent();

    public AddToGuests(string name, string phone, string sex, string photo, int id, string buttonLabel, string pageLabel)
    {
        InitializeComponent();
        NameTextBox.TxtBox.Text = name;
        PhoneTextBox.TxtBox.Text = phone;
        PhotoTextBox.TxtBox.Text = photo;
        GID.Content = id;
        AddBtn.Content = buttonLabel;
        MainGuestLabel.Content = pageLabel;
        if (sex == "♂") Male.IsChecked = true;
        else if (sex == "♀") Female.IsChecked = true;
        else NoSex.IsChecked = true;
    }

    private void GoBack(object sender, RoutedEventArgs e) =>
        NavigationService.Navigate(new Uri("Pages/GuestPage.xaml", UriKind.RelativeOrAbsolute));

    private void AddNewGuestToDb(object sender, RoutedEventArgs e)
    {
        if (AddBtn.Content == "Добавить")
        {
            CheckAndFormatNumber formatNumber = new CheckAndFormatNumber();
            var trueNumber = formatNumber.CheckNumber(PhoneTextBox.TxtBox.Text, out string formatedNumber);

            if (NameTextBox.TxtBox.Text != "" && PhoneTextBox.TxtBox.Text != "" && trueNumber)
            {
                string sex = "";
                if (Male.IsChecked == true) sex = "♂";
                else if (Female.IsChecked == true) sex = "♀";
                else sex = " ";

                string photo = CheckLink.CheckCorrectLink(PhotoTextBox.TxtBox.Text);

                using (HotelDbContext appContext = new HotelDbContext())
                {
                    appContext.Guests.Add(new Guest
                    {
                        Name = NameTextBox.TxtBox.Text,
                        Phone = formatedNumber,
                        Sex = sex,
                        Photo = photo
                    });
                    appContext.SaveChanges();
                }
                NavigationService.Navigate(new Uri("Pages/GuestPage.xaml", UriKind.RelativeOrAbsolute));
            }
            else MessageBox.Show("Введите корректное имя и телефон.\nНомер должен состоять из 7 или 11-13 цифр. Формат не важен.", "Внимание");
        }
        else if (AddBtn.Content == "Сохранить")
        {
            CheckAndFormatNumber formatNumber = new CheckAndFormatNumber();
            var trueNumber = formatNumber.CheckNumber(PhoneTextBox.TxtBox.Text, out string formatedNumber);

            if (NameTextBox.TxtBox.Text != "" && PhoneTextBox.TxtBox.Text != "" && trueNumber)
            {
                string photo = CheckLink.CheckCorrectLink(PhotoTextBox.TxtBox.Text);
                using (HotelDbContext appContext = new HotelDbContext())
                {
                    var guest = appContext.Guests.Where(x => x.Id == (int)GID.Content).FirstOrDefault();
                    guest.Name = NameTextBox.TxtBox.Text;
                    guest.Phone = formatedNumber;
                    guest.Photo = photo;
                    if (Male.IsChecked == true) guest.Sex = "♂";
                    else if (Female.IsChecked == true) guest.Sex = "♀";
                    else guest.Sex = " ";
                    appContext.SaveChanges();
                }
                NavigationService.Navigate(new Uri("Pages/GuestPage.xaml", UriKind.RelativeOrAbsolute));
            }
            else MessageBox.Show("Введите корректное имя и телефон.\nНомер должен состоять из 7 или 11-13 цифр. Формат не важен.", "Внимание");
        }
    }
}
