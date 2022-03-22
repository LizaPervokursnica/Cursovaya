using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

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
