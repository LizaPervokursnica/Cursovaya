using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace HotelAccounting.Elements
{
    /// <summary>
    /// Interaction logic for SearchBox.xaml
    /// </summary>
    public partial class SearchBox : UserControl
    {
        public SearchBox()
        {
            InitializeComponent();
        }
        //Фокус на keyboard
        private void Border_LostFocus(object sender, RoutedEventArgs e)
        {
            if (SearchItemTxt.Text == "")
            {
                LblSearchTxt.Visibility = Visibility.Visible;
                SearchItemTxt.Foreground = new SolidColorBrush(Color.FromRgb(157, 157, 157));
            }
        }
        //Фокус на keyboard
        private void Border_GotFocus(object sender, RoutedEventArgs e)
        {
            LblSearchTxt.Visibility = Visibility.Hidden;
            SearchItemTxt.Foreground = new SolidColorBrush(Colors.White);
        }
    }
}
