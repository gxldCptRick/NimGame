using Nim.Lib.Enums;
using Nim.UI.Controllers;
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

        private void RestartBtn_Click(object sender, RoutedEventArgs e)
        {
            UnlockTheUI();
            MainPageData dc = (MainPageData) this.DataContext;
            dc.GameController.ResetGame();
        }

        private void EndBtn_Clicked(object sender, RoutedEventArgs e)
        {
            UnlockTheUI();
            MainPageData dc = (MainPageData)this.DataContext;
            dc.GameController.ProcessTurn();
            HighlightTheCorrectPlayer();
        }

        private void UnlockTheUI()
        {
            gameArea.SelectedIndex = -1;
            gameArea.Focusable = true;
            canUpdateGameArea = true;
        }

        private void HighlightTheCorrectPlayer()
        {
            if (this.DataContext is MainPageData data)
            {
                if (data.GameController.CurrentTurn == PlayerTurn.PlayerOne)
                {
                    this.Player1.Background = Brushes.Plum;
                    this.Player2.Background = Brushes.Transparent;
                }
                else
                {

                    this.Player1.Background = Brushes.Transparent;
                    this.Player2.Background = Brushes.Plum;
                }
            }
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            HighlightTheCorrectPlayer();
        }
    }
}
