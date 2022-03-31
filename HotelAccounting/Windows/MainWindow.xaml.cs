using HotelAccounting.Pages;
using System;
using System.Windows;
using System.Windows.Input;

namespace HotelAccounting
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        

        public static Window window;
        public MainWindow()
        {
            InitializeComponent();
            window = this;
            PagesNavigation.Navigate(new Uri("Pages/HomePage.xaml", UriKind.RelativeOrAbsolute));
        }

        private void btnClose_Click(object sender, RoutedEventArgs e) => Application.Current.Shutdown();

        private void Drag(object sender, RoutedEventArgs e)
        {
            if (Mouse.LeftButton == MouseButtonState.Pressed) window.DragMove();
        }

        private void btnRestore_Click(object sender, RoutedEventArgs e) =>
            WindowState = WindowState == WindowState.Normal ? WindowState = WindowState.Maximized : WindowState = WindowState.Normal;


        private void btnMinimize_Click(object sender, RoutedEventArgs e) =>
            WindowState = WindowState.Minimized;


        private void rdHome_Click(object sender, RoutedEventArgs e) =>
            PagesNavigation.Navigate(new Uri("Pages/HomePage.xaml", UriKind.RelativeOrAbsolute));


        private void rdSounds_Click(object sender, RoutedEventArgs e) =>
            PagesNavigation.Navigate(new Uri("Pages/GuestPage.xaml", UriKind.RelativeOrAbsolute));


        private void Border_MouseDown_1(object sender, MouseButtonEventArgs e) => Keyboard.ClearFocus();
        
    }
}
