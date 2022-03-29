using HotelAccounting.DataAccess;
using HotelAccounting.Model;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace HotelAccounting.Pages
{
    /// <summary>
    /// Interaction logic for HomePage.xaml
    /// </summary>
    public partial class HomePage : Page
    {
        HotelDbContext context = new HotelDbContext();

        public HomePage()
        {
            InitializeComponent();

            try
            {
                ListV.ItemsSource = context.Rooms.ToList();
            }
            catch
            {
                MessageBox.Show("Ошибка подключеия к базе данных");
            }
        }

        private void ChooseRoom(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;

            if (button.DataContext is Room room)
            {
                MessageBox.Show(room.NameOfRoom);
            }
        }

        private void HouseCBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ListV = new ListView();
            var allRooms = context.Rooms.ToList();

            var selectedIndex = (RoomFilter)HouseCBox.SelectedIndex;

            if (selectedIndex == RoomFilter.Free)
            {
                ListV.ItemsSource = allRooms.Where(x => !x.GuestId.HasValue).ToList();
                return;
            }

            if (selectedIndex == RoomFilter.Occupied)
            {
                ListV.ItemsSource = allRooms.Where(x => x.GuestId.HasValue).ToList();
                return;
            }

            ListV.ItemsSource = allRooms;
        }

        private void SearchBox_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            //var newSource = context.Rooms.ToList();
            //newSource = newSource.Where(x => x.NameOfRoom.Contains(SBox.SearchItemTxt.Text)).ToList();
            //ListV.ItemsSource = newSource;
        }
    }
}
