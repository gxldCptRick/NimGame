using Nim.UI.ViewModels;
using Nim.UI.Views.UserControls;
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
    /// Interaction logic for GamePage.xaml
    /// </summary>
    public partial class GamePage : Page
    {
        private bool canUpdateGameArea;
        public GamePage()
        {
            canUpdateGameArea = true;
            InitializeComponent();
        }

        private void gameArea_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (canUpdateGameArea)
            {
                gameArea.Focusable = false;
                foreach (var item in gameArea.Items)
                {
                    if (gameArea.SelectedItem != item)
                    {
                        ((PileData)item).IsEnabled = false;
                    }
                }
            }
            canUpdateGameArea = false;
        }
    }
}
