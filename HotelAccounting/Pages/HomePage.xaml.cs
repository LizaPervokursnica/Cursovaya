using HotelAccounting.DataAccess;
using HotelAccounting.Model;
using System;
using System.Collections.Generic;
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

        //GC.Collect();
        //GC.WaitForPendingFinalizers();
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
        if (room.GuestId == null)
        {
            var specifRoom = new SpecificRoom(room.NameOfRoom, room.Equipment, room.Photo, room.Id);
            NavigationService.Navigate(specifRoom);
        }
        else if (room.GuestId != null)
        {
            var currRoom = new SpecificRoom(context.Guests.Where(x => x.Id == room.GuestId).ToList(), room.Equipment, 
                room.Photo, room.Id, room.NameOfRoom);
            NavigationService.Navigate(currRoom);
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
       
        ListV.ItemsSource = null;

        IQueryable<Room> list_;
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
        ListV.ItemsSource = roomList;
    }
}