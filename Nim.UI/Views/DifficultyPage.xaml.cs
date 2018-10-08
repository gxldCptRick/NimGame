using Nim.Enums;
using Nim.Lib.Enums;
using Nim.UI.ViewModels;
using System;
using System.Windows;
using System.Windows.Controls;

namespace Nim.UI.Views
{
    /// <summary>
    /// Interaction logic for Difficulty.xaml
    /// </summary>
    public partial class DifficultyPage : Page
    {
        public event Action<Pages> CheckClick;
        public DifficultyPage()
        {
            InitializeComponent();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            if (!(DataContext is null) && (DataContext as MainPageData).GameController.Type == GameType.OnePlayer)
            {
                Player2Display.Visibility = Visibility.Hidden;
            }
            else
            {
                Player2Display.Visibility = Visibility.Visible;
            }
        }

        private void StartGame_Click(object sender, RoutedEventArgs e)
        {
            MainPageData dc = (MainPageData)DataContext;
            GameDifficulty gd = GameDifficulty.Easy;
            if (rdoEasy.IsChecked == true)
            {
                gd = GameDifficulty.Easy;
            }
            else if (rdoMedium.IsChecked == true)
            {
                gd = GameDifficulty.Medium;
            }
            else if (rdoHard.IsChecked == true)
            {
                gd = GameDifficulty.Hard;
            }
            dc.GameController.Difficulty = gd;

            if (CheckClick != null) CheckClick(Pages.Game);
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            CheckClick(Pages.MainMenu);
        }
    }
}
