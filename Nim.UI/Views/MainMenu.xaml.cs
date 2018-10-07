using System;
using System.Collections.Generic;
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

namespace Nim.UI.Views
{
    /// <summary>
    /// Interaction logic for MainMenu.xaml
    /// </summary>
    public partial class MainMenu : Page
    {
        public event Action<string> CheckClick;

        public MainMenu()
        {
            InitializeComponent();
        }

        private void SinglePlayerClick(object sender, RoutedEventArgs e)
        {
            
        }

        private void TwoPlayerClick(object sender, RoutedEventArgs e)
        {

        }

        private void HalpClick(object sender, RoutedEventArgs e)
        {
            
        }

        private void SettingsClick(object sender, RoutedEventArgs e)
        {

        }
    }
}
