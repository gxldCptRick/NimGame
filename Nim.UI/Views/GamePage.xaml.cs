using Nim.Lib.Enums;
using Nim.UI.ViewModels;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Media;

namespace Nim.UI.Views
{
    /// <summary>
    /// Interaction logic for GamePage.xaml
    /// </summary>
    public partial class GamePage : Page, INotifyPropertyChanged
    {
        private bool canUpdateGameArea;
        private bool _firstMoveMade;

        public event PropertyChangedEventHandler PropertyChanged;

        public bool FirstMoveMade
        {
            get => _firstMoveMade; private set
            {
                _firstMoveMade = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("FirstMoveMade"));
            }
        }

        public GamePage()
        {
            canUpdateGameArea = true;
            InitializeComponent();
            var binding = new Binding("FirstMoveMade")
            {
                Source = this
            };

            EndBtn.SetBinding(Button.IsEnabledProperty, binding);
        }

        private void gameArea_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (canUpdateGameArea)
            {
                GameArea.Focusable = false;
                foreach (var item in GameArea.Items)
                {
                    if (GameArea.SelectedItem != item)
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
            MainPageData dc = (MainPageData)DataContext;
            dc.GameController.ResetGame();
        }

        private void EndBtn_Clicked(object sender, RoutedEventArgs e)
        {
            if (FirstMoveMade)
            {
                UnlockTheUI();
                MainPageData dc = (MainPageData)DataContext;
                dc.GameController.ProcessTurn();
                HighlightTheCorrectPlayer();
                FirstMoveMade = false;
            }

        }

        private void UnlockTheUI()
        {
            GameArea.SelectedIndex = -1;
            GameArea.Focusable = true;
            canUpdateGameArea = true;
        }

        private void HighlightTheCorrectPlayer()
        {
            if (DataContext is MainPageData data)
            {
                if (data.GameController.CurrentTurn == PlayerTurn.PlayerOne)
                {
                    Player1.Background = Brushes.Plum;
                    Player2.Background = Brushes.Transparent;
                }
                else
                {

                    Player1.Background = Brushes.Transparent;
                    Player2.Background = Brushes.Plum;
                }
            }
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            HighlightTheCorrectPlayer();
            foreach (var item in GameArea.Items)
            {
                if (item is PileData data)
                {
                    data.ActionDid += () => FirstMoveMade = true;
                }
            }
        }
    }
}
