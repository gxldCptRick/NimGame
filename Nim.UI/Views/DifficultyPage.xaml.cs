using Nim.Enums;
using Nim.Lib.Enums;
using Nim.UI.Controllers;
using Nim.UI.ViewModels;
using System;
using System.IO;
using System.Windows;
using System.Windows.Controls;

namespace Nim.UI.Views
{
    /// <summary>
    /// Interaction logic for Difficulty.xaml
    /// </summary>
    public partial class DifficultyPage : Page
    {
        private static readonly string[] babyNames;
        static DifficultyPage(){
            babyNames = File.ReadAllLines("Resources/Names.txt");
        }
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

            if (DataContext is MainPageData data && data.GameController.Type == GameType.OnePlayer) data.P2Name = babyNames[NimController.rnJesus.Next(0, babyNames.Length)];

            if (CheckClick != null) CheckClick(Pages.Game);
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            CheckClick(Pages.MainMenu);
        }
    }
}
