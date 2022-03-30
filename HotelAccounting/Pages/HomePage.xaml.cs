using HotelAccounting.DataAccess;
using HotelAccounting.Model;
using System;
using System.Collections.ObjectModel;
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
                ListV.ItemsSource = context.Rooms.OrderBy(x => x.Id).ToList();
            }
            catch { MessageBox.Show("Ошибка подключеия к базе данных", "Ошибка!", MessageBoxButton.OK); }
        }

        private void ChooseRoom(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;

            if (button.DataContext is Room room)
            {
                MessageBox.Show(room.NameOfRoom);
            }
        }

        private void HouseCBox_SelectionChanged(object sender, SelectionChangedEventArgs e) => UpdateList();

        private void SearchBox_KeyDown(object sender, System.Windows.Input.KeyEventArgs e) => UpdateList();

       public void UpdateList()
        {
            GC.Collect();
            GC.WaitForPendingFinalizers();

            if (ListV == null) ListV = new ListView();

            if (SBox == null) SBox = new Elements.SearchBox();
            string searchText = SBox.SearchItemTxt.Text;

            var selectedIndex = (RoomFilter)HouseCBox.SelectedIndex;

            if (selectedIndex == RoomFilter.Free)
            {
                ListV.ItemsSource = null;
                var freeList = searchText == "" ? context.Rooms.Where(x => !x.GuestId.HasValue).OrderBy(x => x.Id).ToList() : context.Rooms.Where(x => !x.GuestId.HasValue && (x.Equipment.ToLower().Contains(searchText) || x.NameOfRoom.ToLower().Contains(searchText))).OrderBy(x => x.Id).ToList();
                var freeObservableCollection = new ObservableCollection<Room>();
                ListV.ItemsSource = freeObservableCollection;
                freeList.ForEach(x => freeObservableCollection.Add(x));
                return;
            }

            if (selectedIndex == RoomFilter.Occupied)
            {
                ListV.ItemsSource = null;
                var occupiedList = searchText == "" ? context.Rooms.Where(x => x.GuestId.HasValue).OrderBy(x => x.Id).ToList() : context.Rooms.Where(x => x.GuestId.HasValue && (x.Equipment.ToLower().Contains(searchText) || x.NameOfRoom.ToLower().Contains(searchText))).OrderBy(x => x.Id).ToList();
                var occupiedObservableCollection = new ObservableCollection<Room>();
                ListV.ItemsSource = occupiedObservableCollection;
                occupiedList.ForEach(x => occupiedObservableCollection.Add(x));
                return;
            }
            else
            {
                ListV.ItemsSource = null;
                var list = searchText == "" ? context.Rooms.OrderBy(x => x.Id).ToList() : context.Rooms.Where(x => x.Equipment.ToLower().Contains(searchText) || x.NameOfRoom.ToLower().Contains(searchText)).OrderBy(x => x.Id).ToList();
                var observableCollection = new ObservableCollection<Room>();
                ListV.ItemsSource = observableCollection;
                list.ForEach(x => observableCollection.Add(x));
            }
        }
    }
}
