using HotelAccounting.DataAccess;
using HotelAccounting.Model;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

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
            if (ListV == null)
            {
                ListV = new ListView();
            }
           

            var selectedIndex = (RoomFilter)HouseCBox.SelectedIndex;

            if (selectedIndex == RoomFilter.Free)
            {
                ListV.ItemsSource = null;
                var freeList = context.Rooms.Where(x => !x.GuestId.HasValue).ToList();
                var freeObservableCollection = new ObservableCollection<Room>();
                ListV.ItemsSource = freeObservableCollection;

                freeList.ForEach(x => freeObservableCollection.Add(x));

                return;
            }

            if (selectedIndex == RoomFilter.Occupied)
            {
                ListV.ItemsSource = null;
                var occupiedList = context.Rooms.Where(x => x.GuestId.HasValue).ToList();
                var occupiedObservableCollection = new ObservableCollection<Room>();
                ListV.ItemsSource = occupiedObservableCollection;

                occupiedList.ForEach(x => occupiedObservableCollection.Add(x));

                return;
            }

            ListV.ItemsSource = null;
            var list = context.Rooms.ToList();
            var observableCollection = new ObservableCollection<Room>();
            ListV.ItemsSource = observableCollection;

            list.ForEach(x => observableCollection.Add(x));
        }

        private void SearchBox_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            //var newSource = context.Rooms.ToList();
            //newSource = newSource.Where(x => x.NameOfRoom.Contains(SBox.SearchItemTxt.Text)).ToList();
            //ListV.ItemsSource = newSource;
        }
    }
}
