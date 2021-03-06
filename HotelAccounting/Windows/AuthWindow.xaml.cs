using HotelAccounting.Classes;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using HotelAccounting.DataAccess;

namespace HotelAccounting.Windows;
/// <summary>
/// Interaction logic for AuthWindow.xaml
/// </summary>
public partial class AuthWindow : Window
{
    public Window window;
    public HotelDbContext context = new();
    public AuthWindow()
    {
        InitializeComponent();
        window = this;
    }

    private async void AuthBtn_Click(object sender, RoutedEventArgs e) => AUTH();
    
    private async Task AUTH()
    {
        var success = await Authorization.CheckLogAndPass(loginTBox.TxtBox.Text.Trim(), passwordBox.PassBox.Password.Trim(), context);
        if (success)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            Hide();
        }
        else MessageBox.Show("Ошибка. Введён неверный логин или пароль.", "Ошибка!", MessageBoxButton.OK);
    }

    private void btnClose_Click(object sender, RoutedEventArgs e) => Application.Current.Shutdown();

    private void btnRestore_Click(object sender, RoutedEventArgs e) =>
        WindowState = WindowState == WindowState.Normal ? WindowState = WindowState.Maximized : WindowState = WindowState.Normal;

    private void btnMinimize_Click(object sender, RoutedEventArgs e) =>
        WindowState = WindowState.Minimized;

    private void Border_MouseDown(object sender, MouseButtonEventArgs e) =>
        Keyboard.ClearFocus();

    private void Drag(object sender, MouseButtonEventArgs e)
    {
        if (Mouse.LeftButton == MouseButtonState.Pressed) window.DragMove();
    }
}

