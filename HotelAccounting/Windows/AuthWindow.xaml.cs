using System.Linq;
using System.Windows;
using System.Windows.Input;
using HotelAccounting.Classes;

namespace HotelAccounting.Windows
{
    /// <summary>
    /// Interaction logic for AuthWindow.xaml
    /// </summary>
    public partial class AuthWindow : Window
    {
        public Window window;
        public AuthWindow()
        {
            InitializeComponent();
            window = this;
        }

        private void AuthBtn_Click(object sender, RoutedEventArgs e)
        {
            var success = Authorization.CheckLogAndPass(loginTBox.TxtBox.Text, passwordBox.PassBox.Password);
            if (success == "true")
            {
                MainWindow mainWindow = new MainWindow();
                mainWindow.Show();
                Hide();
            }
            else if (success == "noConnect") MessageBox.Show("Произошла ошибка соединения с базой данных.", "Ошибка!", MessageBoxButton.OK);
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
}
