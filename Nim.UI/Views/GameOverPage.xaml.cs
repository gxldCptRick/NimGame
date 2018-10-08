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
using Nim.Enums;

namespace Nim.UI.Views
{
    /// <summary>
    /// Interaction logic for GameOver.xaml
    /// </summary>
    public partial class GameOver : Page
    {
        public event Action<Pages> CheckClick;

        public GameOver()
        {
            InitializeComponent();
        }

        private void Restart_Click(object sender, RoutedEventArgs e)
        {
            CheckClick(Pages.Game);
        }

        private void ChangeDifficulty_Click(object sender, RoutedEventArgs e)
        {
            CheckClick(Pages.Difficulty);
        }

        private void MainMenu_Click(object sender, RoutedEventArgs e)
        {
            CheckClick(Pages.MainMenu);
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
