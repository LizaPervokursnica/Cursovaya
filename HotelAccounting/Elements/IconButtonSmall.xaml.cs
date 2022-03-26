using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace HotelAccounting.Elements
{
    /// <summary>
    /// Interaction logic for IconButtonSmall.xaml
    /// </summary>
    public partial class IconButtonSmall : UserControl
    {
        public PathGeometry BtnIcon { get; set; }
        public IconButtonSmall()
        {
            InitializeComponent();
            DataContext = this;
        }
        private void Grid_MouseEnter(object sender, MouseEventArgs e)
        {
            //AddUpBorder.Background = new SolidColorBrush(Color.FromRgb(108, 84, 206));
            //IconAddUp.Opacity = 1.0;
        }

        private void Grid_MouseLeave(object sender, MouseEventArgs e)
        {
            //AddUpBorder.Background = new SolidColorBrush(Color.FromRgb(31, 32, 39));
            //IconAddUp.Opacity = 0.5;
        }
    }
}
