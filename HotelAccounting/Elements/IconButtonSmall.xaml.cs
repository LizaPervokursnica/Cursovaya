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
    }
}
