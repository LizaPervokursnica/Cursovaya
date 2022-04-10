using System.Windows.Controls;
using System.Windows.Media;

namespace HotelAccounting.Elements;

/// <summary>
/// Interaction logic for IconButtonBig.xaml
/// </summary>
public partial class IconButtonBig : UserControl
{
    public PathGeometry BtnIcon { get; set; }

    public IconButtonBig()
    {
        InitializeComponent();
        DataContext = this;
    }
}