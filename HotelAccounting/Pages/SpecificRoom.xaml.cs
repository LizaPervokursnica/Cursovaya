using HotelAccounting.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Navigation;

namespace HotelAccounting.Pages
{
    /// <summary>
    /// Interaction logic for SpecificRoom.xaml
    /// </summary>
    public partial class SpecificRoom : Page
    {
        public string PhotoURL { get; set; }
        public int RoomID { get; set; }
        public SpecificRoom()
        {
            InitializeComponent();
            DataContext = this;
            HotelDbContext dbContext = new HotelDbContext();
            GComboBox.ItemsSource = dbContext.Guests.ToList();
        }

        public SpecificRoom(string status, SolidColorBrush foreground, 
            List<Guest> guests, int selectedIndex, bool enable, string btnText,
            string equipment, string photo, int id, string roomName)
        {
            InitializeComponent();
            DataContext = this;
            HotelDbContext dbContext = new HotelDbContext();
            GComboBox.ItemsSource = dbContext.Guests.ToList();

            RoomStatus.Content = status;
            RoomStatus.Foreground = foreground;
            GComboBox.ItemsSource = guests;
            GComboBox.SelectedIndex = selectedIndex;
            GComboBox.IsEnabled = enable;
            StatusChangeBtn.Content = btnText;
            RoomDescription.Text = equipment;
            PhotoURL = photo;
            RoomID = id;
            RoomNameLabel.Content = roomName;
        }

        public SpecificRoom(string roomName, SolidColorBrush foreground, string status, 
            string content, string equipment, string photo, int id)
        {
            InitializeComponent();
            DataContext = this;
            HotelDbContext dbContext = new HotelDbContext();
            GComboBox.ItemsSource = dbContext.Guests.ToList();

            RoomStatus.Content = status;
            RoomStatus.Foreground = foreground;
            RoomDescription.Text = equipment;
            StatusChangeBtn.Content = content;
            PhotoURL = photo;
            RoomID = id;
            RoomNameLabel.Content = roomName;
        }

        private void GoBack(object sender, RoutedEventArgs e) => BackMove();

        private void BackMove() =>
            NavigationService.Navigate(new Uri("Pages/HomePage.xaml", UriKind.RelativeOrAbsolute));

        private void CheckInOutRoom_Click(object sender, RoutedEventArgs e)
        {
            if (StatusChangeBtn.Content == "Вселить")
            {
                if (GComboBox.SelectedItem != null)
                {
                    using (HotelDbContext dbContext = new HotelDbContext())
                    {
                        var guest = GComboBox.SelectedItem as Guest;
                        var room = dbContext.Rooms.Where(x => x.Id == RoomID).FirstOrDefault();
                        room.GuestId = guest.Id;
                        dbContext.SaveChanges();
                    }
                    BackMove();
                }
                else MessageBox.Show("Выберите гостя в выпадающем списке", "Внимание");
            }
            else if (StatusChangeBtn.Content == "Выселить")
            {
                using (HotelDbContext dbContext = new HotelDbContext())
                {
                    var room = dbContext.Rooms.Where(x => x.Id == RoomID).FirstOrDefault();
                    room.GuestId = null;
                    dbContext.SaveChanges();
                }
                BackMove();
            }
        }
    }
}
