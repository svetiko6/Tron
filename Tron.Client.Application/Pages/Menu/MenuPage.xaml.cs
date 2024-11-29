using System;
using System.Collections.Generic;
using System.Configuration;
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
//using Tron.Client.Application.Pages.Singleplayer;
using Tron.Client.Application.Pages.Multiplayer;
using Tron.Client.Application.Pages.Settings;
using System.Windows.Media.Animation;
using Tron.Client.Application.Pages.Tracks;
using Tron.Client.Networking;

namespace Tron.Client.Application.Pages.Menu
{
    /// <summary>
    /// Interaction logic for MenuPage.xaml
    /// </summary>
    public partial class MenuPage : Page
    {
        public MenuPage()
        {
            InitializeComponent();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            this.Focus();
        }

        private void SingleplayerButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new SmallTrack());
        }

        private void MultiplayerButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new CreateOrJoinPage());
        }

        private void SettingsButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new SettingsPage());
        }

        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            Exit();
        }

        private void Page_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Escape)
            {
                Exit();
            }
        }

        private void Exit()
        {
            App.Current.Shutdown();
        }
    }
}
