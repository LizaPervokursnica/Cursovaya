using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace HotelAccounting.Elements
{
    /// <summary>
    /// Логика взаимодействия для CuteTextBox.xaml
    /// </summary>
    public partial class CuteTextBox : UserControl
    {
        public string Title { get; set; }
        public CuteTextBox()
        {
            InitializeComponent();
            DataContext = this;
        }
        private void Nametxtbox_LostKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            if (TxtBox.Text == "")
            {
                lbl.VerticalAlignment = VerticalAlignment.Center; 
                lbl.FontSize = 13;
            }
        }

        private void Nametxtbox_GotKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            lbl.VerticalAlignment = VerticalAlignment.Top; 
            lbl.FontSize = 11;
        }

        private void brdr_Loaded(object sender, RoutedEventArgs e)
        {
            if (TxtBox.Text != "")
            {
                lbl.VerticalAlignment = VerticalAlignment.Top;
                lbl.FontSize = 11;
            }
        }
    }
}
