using System;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using System.Windows.Controls;
using HotelAccounting.DataAccess;
using System.Collections.ObjectModel;

namespace HotelAccounting.Pages
{
    /// <summary>
    /// Interaction logic for GuestPage.xaml
    /// </summary>
    public partial class GuestPage : Page
    {
        HotelDbContext context = new HotelDbContext();
        public GuestPage()
        {
            InitializeComponent();

            GC.Collect();
            GC.WaitForPendingFinalizers();

            try
            {
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
                toGuests.PhotoTextBox.TxtBox.Text = guest.Photo;
                NavigationService.Navigate(toGuests);
            }
            else MessageBox.Show("Не выбран элемент для редактирования", "Выберите элемент", MessageBoxButton.OK);
        }

        private void DeleteLogicBtn_Click(object sender, MouseButtonEventArgs e)
        {
            Guest guest = ListV.SelectedItem as Guest;
            if (guest != null)
            {
                var move = MessageBox.Show("Вы точно хотите удалить выбранный элемент?", "Внимание!", MessageBoxButton.YesNo);
                if (move == MessageBoxResult.Yes)
                {
                    context.Guests.Remove(context.Guests.Find(guest.Id));
                    context.SaveChanges();
                    ListV.ItemsSource = context.Guests.ToArray();
                }
            }
            else MessageBox.Show("Не выбран элемент для удаления", "Выберите элемент", MessageBoxButton.OK);
        }

        private void SBox_KeyDown(object sender, KeyEventArgs e)
        {
            GC.Collect();

            if (ListV == null) ListV = new ListView();

            if (SBox == null) SBox = new Elements.SearchBox();

            string? searchText = SBox.SearchItemTxt.Text;

            ListV.ItemsSource = null;
            var list = searchText == "" ? context.Guests.OrderBy(x => x.Id).ToList() : context.Guests.Where(x => x.Name.ToLower().Contains(searchText) || x.Phone.ToLower().Contains(searchText)).OrderBy(x => x.Id).ToList();
            var observableCollection = new ObservableCollection<Guest>();
            ListV.ItemsSource = observableCollection;

            list.ForEach(x => observableCollection.Add(x));
        }
    }
}
