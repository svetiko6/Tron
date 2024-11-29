using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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
using Tron.Client.Application.Pages.Tracks;
using Tron.Client.Networking;
using Tron.Common.Config.Utilities;
using Tron.Common.Networking.P2P;

namespace Tron.Client.Application.Pages.Multiplayer
{
    /// <summary>
    /// Interaction logic for CreateOrJoinPage.xaml
    /// </summary>
    public partial class CreateOrJoinPage : Page
    {
        public CreateOrJoinPage()
        {
            InitializeComponent();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            this.Focus();
        }

        private void CreateButton_Click(object sender, RoutedEventArgs e)
        {
            (System.Windows.Application.Current as App)!.ConnectToServer();
            NavigationService.Navigate(new CreateLobbyPage());
        }

        private void JoinButton_Click(object sender, RoutedEventArgs e)
        {
            (System.Windows.Application.Current as App)!.ConnectToServer();
            NavigationService.Navigate(new JoinLobbyPage());
        }

        private void LocalButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new SmallTrack());
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            GoBack();
        }

        private void Page_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Escape)
            {
                GoBack();
            }
        }

        private void GoBack()
        {
            NavigationService.GoBack();
        }
    }
}
