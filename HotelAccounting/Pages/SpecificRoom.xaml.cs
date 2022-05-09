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

        HotelDbContext dbContext = new HotelDbContext();
        public SpecificRoom()
        {
            InitializeComponent();
            DataContext = this;
        }

        public SpecificRoom(string roomName, string equipment, string photo, int id) : this()
        {
            GComboBox.ItemsSource = dbContext.Guests.ToList();
            RoomStatus.Content = "Свободен";
            RoomStatus.Foreground = new SolidColorBrush(Colors.Green);
            StatusChangeBtn.Content = "Вселить";
            
            RoomNameLabel.Content = roomName;
            RoomDescription.Text = equipment;
            PhotoURL = photo;
            RoomID = id;
        }

        public SpecificRoom(List<Guest> guests, string equipment, string photo, int id, string roomName) : this()
        {
            RoomStatus.Content = "Занят";
            RoomStatus.Foreground = new SolidColorBrush(Colors.Red);
            StatusChangeBtn.Content = "Выселить";

            GComboBox.ItemsSource = guests;
            GComboBox.SelectedIndex = 0;
            GComboBox.IsEnabled = false;

            RoomDescription.Text = equipment;
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
