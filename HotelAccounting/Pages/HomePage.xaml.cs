using System;
using System.Collections.Generic;
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
        ApplicationContext context = new ApplicationContext();

        public HomePage()
        {
            InitializeComponent();
            try 
            {
                ListV.ItemsSource = context.Rooms.ToList();
            }
            catch { MessageBox.Show("Ошибка подключеия к базе данных"); }
        }

        private void ChooseRoom(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            var room = button.DataContext as Room;

            //var room = ListV.SelectedItem as Room;
            if (room != null) MessageBox.Show(room.NameOfRoom);

        }

        private void HouseCBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (HouseCBox.SelectedIndex != 0)
            {
                var newSource = context.Rooms.ToList();
                if (HouseCBox.SelectedIndex == 1)
                    newSource = newSource.Where(x => x.GuestId == null).ToList();

                else if (HouseCBox.SelectedIndex == 2)
                    newSource = newSource.Where(x => x.GuestId != null).ToList();
                else
                    ListV.ItemsSource = context.Rooms.ToArray();
                ListV.ItemsSource = newSource;
            }
        }

        private void SearchBox_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            //var newSource = context.Rooms.ToList();
            //newSource = newSource.Where(x => x.NameOfRoom.Contains(SBox.SearchItemTxt.Text)).ToList();
            //ListV.ItemsSource = newSource;
        }
    }
}
