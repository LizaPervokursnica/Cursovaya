using HotelAccounting.DataAccess;
using HotelAccounting.Elements;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace HotelAccounting.Pages;

/// <summary>
/// Interaction logic for GuestPage.xaml
/// </summary>
public partial class GuestPage : Page
{
    HotelDbContext context = new HotelDbContext();
    public GuestPage()
    {
        InitializeComponent();

        GC.Collect();
        GC.WaitForPendingFinalizers();

        try
        {
            ListV.ItemsSource = context.Guests.ToArray();
        }
        catch { MessageBox.Show("Ошибка подключеия к базе данных", "Ошибка!", MessageBoxButton.OK); }
    }

    private void AddToDb_Click(object sender, MouseButtonEventArgs e)
    {
        AddToGuests toGuests = new AddToGuests();
        NavigationService.Navigate(toGuests);
    }

    private void SBox_KeyDown(object sender, KeyEventArgs e)
    {
        GC.Collect();

        if (ListV == null) ListV = new ListView();
        if (SBox == null) SBox = new SearchBox();

        string searchText = SBox.SearchItemTxt.Text;
        ListV.ItemsSource = null;

        var list = searchText == "" ? context.Guests.OrderBy(x => x.Id).ToList() : 
            context.Guests.Where(x => x.Name.ToLower().Contains(searchText) || 
        x.Phone.ToLower().Contains(searchText)).OrderBy(x => x.Id).ToList();

        var observableCollection = new ObservableCollection<Guest>();
        ListV.ItemsSource = observableCollection;

        list.ForEach(x => observableCollection.Add(x));
    }

    private void EditLogicBtn_Click(object sender, RoutedEventArgs e)
    {
        var button = sender as Button;

        if (button.DataContext is Guest guest)
        {
            AddToGuests toGuests = new AddToGuests(guest.Name, guest.Phone, guest.Sex, guest.Photo, guest.Id, "Сохранить", "Редактирование");
            NavigationService.Navigate(toGuests);
        }
        else MessageBox.Show("Не выбран элемент для редактирования", "Выберите элемент", MessageBoxButton.OK);
    }

    private void DeleteThis(object sender, RoutedEventArgs e) 
    {
        var button = sender as Button;

        if (button.DataContext is Guest guest)
        {
            var move = MessageBox.Show("Вы точно хотите удалить выбранный элемент?", "Внимание!", MessageBoxButton.YesNo);
            if (move == MessageBoxResult.Yes)
            {
                context.Guests.Remove(context.Guests.Find(guest.Id));
                context.SaveChanges();
                ListV.ItemsSource = context.Guests.ToArray();
            }
        }
        else MessageBox.Show("Не выбран элемент для удаления", "Выберите элемент", MessageBoxButton.OK);
    }
}