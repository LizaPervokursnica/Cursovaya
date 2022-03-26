using System;
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
        public HomePage()
        {
            InitializeComponent();
            ApplicationContext context = new ApplicationContext();
            try { ListV.ItemsSource = context.Rooms.ToArray();}
            catch { MessageBox.Show("Ошибка подключеия к базе данных"); }
        }

        private void ChooseRoom(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            var room = button.DataContext as Room;

            //var room = ListV.SelectedItem as Room;
            if (room != null) MessageBox.Show(room.NameOfRoom);

        }
    }
}
