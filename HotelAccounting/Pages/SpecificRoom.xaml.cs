using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using HotelAccounting.DataAccess;

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

        private void GoBack(object sender, RoutedEventArgs e) => BackMove();

        private void BackMove() =>         
            NavigationService.Navigate(new Uri("Pages/HomePage.xaml", UriKind.RelativeOrAbsolute));
        
        private void CheckInOutRoom_Click(object sender, RoutedEventArgs e)
        {
            if(StatusChangeBtn.Content == "Вселить")
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
            else if(StatusChangeBtn.Content == "Выселить")
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
