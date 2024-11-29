using System.Configuration;
using System.Data;
using System.Windows;

namespace Tron.Client.Application
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : System.Windows.Application
    {
        public bool ConnectionEstablished { get; set; }

        public App()
        {
            ConnectionEstablished = false;
        }
        
        public void ConnectToServer()
        {
            
        }
    }
}
