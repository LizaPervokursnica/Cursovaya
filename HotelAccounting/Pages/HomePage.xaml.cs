using HotelAccounting.DataAccess;
using HotelAccounting.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace HotelAccounting.Pages;

/// <summary>
/// Interaction logic for HomePage.xaml
/// </summary>
public partial class HomePage : Page
{
    HotelDbContext context = new HotelDbContext();
   
    public HomePage()
    {
        InitializeComponent();

        GC.Collect();
        GC.WaitForPendingFinalizers();

        try
        {
            ListV.ItemsSource = context.Rooms.OrderBy(x => x.Id).ToList();
        }
        catch { MessageBox.Show("Ошибка подключеия к базе данных", "Ошибка!", MessageBoxButton.OK); }
    }

    private void ChooseRoom(object sender, RoutedEventArgs e)
    {
        var button = sender as Button;
        if (button.DataContext is Room room) MoveToMain(room);
    }
    private void TextBlock_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
    {
        var button = sender as TextBlock;
        if (button.DataContext is Room room) MoveToMain(room);
    }

    private void MoveToMain(Room room)
    {
        var specifRoom = new SpecificRoom();
        specifRoom.RoomNameLabel.Content = room.NameOfRoom;
        if (room.GuestId == null)
        {
            specifRoom.RoomStatus.Content = "Свободен";
            specifRoom.RoomStatus.Foreground = new SolidColorBrush(Colors.Green);
            specifRoom.StatusChangeBtn.Content = "Вселить";
        }
        else if (room.GuestId != null)
        {
            specifRoom.RoomStatus.Content = "Занят";
            specifRoom.RoomStatus.Foreground = new SolidColorBrush(Colors.Red);
            specifRoom.GComboBox.ItemsSource = context.Guests.Where(x => x.Id == room.GuestId).ToList();
            specifRoom.GComboBox.SelectedIndex = 0;
            specifRoom.GComboBox.IsEnabled = false;
            specifRoom.StatusChangeBtn.Content = "Выселить";
        }
        specifRoom.RoomDescription.Text = room.Equipment;
        specifRoom.PhotoURL = room.Photo;
        specifRoom.RoomID = room.Id;
        NavigationService.Navigate(specifRoom);
    }

    private void HouseCBox_SelectionChanged(object sender, SelectionChangedEventArgs e) => UpdateList();

    private void SearchBox_KeyDown(object sender, System.Windows.Input.KeyEventArgs e) => UpdateList();

    public void UpdateList()
    {
        if (ListV == null) ListV = new ListView();
        if (SBox == null) SBox = new Elements.SearchBox();

        string searchText = SBox.SearchItemTxt.Text;
        var selectedIndex = (RoomFilter)HouseCBox.SelectedIndex;

        if (selectedIndex == RoomFilter.Free)
        {
            UseRoomFilter(searchText, RoomFilter.Free);
            return;
        }

        if (selectedIndex == RoomFilter.Occupied)
        {
            UseRoomFilter(searchText, RoomFilter.Occupied);
            return;
        }
        else UseRoomFilter(searchText, RoomFilter.All);
    }

    private void UseRoomFilter(string searchText, RoomFilter roomFilter)
    {
        GC.Collect();
        GC.WaitForPendingFinalizers();

        ListV.ItemsSource = null;
        IQueryable<Room> list_;
        var freeObservableCollection = new ObservableCollection<Room>();
        List<Room> roomList = new();

        if (searchText == "")
        {
            list_ = roomFilter switch
            {
                RoomFilter.Free => context.Rooms.Where(x => !x.GuestId.HasValue),
                RoomFilter.Occupied => context.Rooms.Where(x => x.GuestId.HasValue),
                _ => context.Rooms
            };
        }
        else
        {
            list_ = roomFilter switch
            {
                RoomFilter.Free => context.Rooms.Where(x => !x.GuestId.HasValue && (x.Equipment.ToLower().Contains(searchText) || x.NameOfRoom.ToLower().Contains(searchText))),
                RoomFilter.Occupied => context.Rooms.Where(x => x.GuestId.HasValue && (x.Equipment.ToLower().Contains(searchText) || x.NameOfRoom.ToLower().Contains(searchText))),
                _ => context.Rooms.Where(x => x.Equipment.ToLower().Contains(searchText) || x.NameOfRoom.ToLower().Contains(searchText))
            };
        }

        roomList = list_.OrderBy(x => x.Id).ToList();
        ListV.ItemsSource = freeObservableCollection;
        roomList.ForEach(x => freeObservableCollection.Add(x));
    }
}