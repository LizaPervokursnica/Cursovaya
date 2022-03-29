using System;
using System.Linq;
using System.Windows;
using System.Windows.Input;
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

        private void AddToDb_Click(object sender, MouseButtonEventArgs e) =>
            NavigationService.Navigate(new Uri("Pages/AddToGuests.xaml", UriKind.RelativeOrAbsolute));

        private void EditLogicBtn_Click(object sender, MouseButtonEventArgs e)
        {
            Guest? guest = ListV.SelectedItem as Guest;

            if (guest != null)
            {
                AddToGuests toGuests = new AddToGuests();
                toGuests.NameTextBox.TxtBox.Text = guest.Name;
                toGuests.PhoneTextBox.TxtBox.Text = guest.Phone;
                if (guest.Sex == "Мужской") toGuests.Male.IsChecked = true;
                else if (guest.Sex == "Женский") toGuests.Female.IsChecked = true;
                else toGuests.NoSex.IsChecked = true;
                //toGuests.PhoneTextBox.TxtBox.Text = guest.;
                NavigationService.Navigate(toGuests);
            }
            else MessageBox.Show("Не выбран элемент для редактирования", "Выберите элемент", MessageBoxButton.OK);
        }

        private void DeleteLogicBtn_Click(object sender, MouseButtonEventArgs e)
        {
            Guest? guest = ListV.SelectedItem as Guest;
            if (guest != null)
            {
                var move = MessageBox.Show("Вы точно хотите удалить выбранный элемент?", "Внимание!", MessageBoxButton.YesNo);
                if (move == MessageBoxResult.Yes)
                {

                }
            }
            else MessageBox.Show("Не выбран элемент для удаления", "Выберите элемент", MessageBoxButton.OK);
        }
    }
}
