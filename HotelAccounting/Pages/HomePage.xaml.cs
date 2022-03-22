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
    }
}
