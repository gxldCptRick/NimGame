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
using Nim.UI.ViewModels;

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
            if(this.DataContext is MainPageData mainPage)
            {
                mainPage.GameController.ResetGame();
            }
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

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            if(DataContext is MainPageData data)
            {
                string ending = " has won!!!";
                switch (data.GameController.CurrentTurn)
                {
                    case Lib.Enums.PlayerTurn.PlayerOne:
                        lblWinner.Content = data.P2Name;
                        break;
                    case Lib.Enums.PlayerTurn.PlayerTwo:
                        lblWinner.Content = data.P1Name;
                        break;
                    default:
                        throw new ArgumentException("UnsupportedTurn Is Being Used.");
                }

                lblWinner.Content += ending;
            }
        }
    }
}
