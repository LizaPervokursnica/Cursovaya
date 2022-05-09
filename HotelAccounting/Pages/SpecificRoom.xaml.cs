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
        public string statusTitle { get; set; }
        public string buttonTitle { get; set; }
        public string roomLabel { get; set; }
        public string roomEquipment { get; set; }
        public SolidColorBrush brushForeground { get; set; }

        HotelDbContext dbContext = new HotelDbContext();
        public SpecificRoom(string roomName, string photo, int id, string equipment)
        {
            InitializeComponent();
            DataContext = this;
            roomLabel = roomName;
            PhotoURL = photo;
            RoomID = id;
            roomEquipment = equipment;
        }

        public SpecificRoom(string roomName, string equipment, string photo, int id) : this(roomName, photo, id, equipment)
        {
            GComboBox.ItemsSource = dbContext.Guests.ToList();
            statusTitle = "Свободен";
            brushForeground = new SolidColorBrush(Colors.Green);
            buttonTitle = "Вселить";
        }

        public SpecificRoom(List<Guest> guests, string equipment, string photo, int id, string roomName) : this(roomName, photo, id, equipment)
        {
            statusTitle = "Занят";
            brushForeground = new SolidColorBrush(Colors.Red);
            buttonTitle = "Выселить";

            GComboBox.ItemsSource = guests;
            GComboBox.SelectedIndex = 0;
            GComboBox.IsEnabled = false;   
        }

        private void GoBack(object sender, RoutedEventArgs e) => BackMove();

        private void BackMove() =>
            NavigationService.Navigate(new Uri("Pages/HomePage.xaml", UriKind.RelativeOrAbsolute));

        private void CheckInOutRoom_Click(object sender, RoutedEventArgs e)
        {
            if (buttonTitle == "Вселить")
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
            else if (buttonTitle == "Выселить")
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
