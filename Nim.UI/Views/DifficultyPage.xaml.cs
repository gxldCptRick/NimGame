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
using Nim.Lib.Enums;
using Nim.UI.ViewModels;
using Nim.UI.Views.UserControls;
using Nim.Enums;

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
            if(!(DataContext is null)&& (DataContext as MainPageData).GameController.Type == GameType.OnePlayer)
            {
                this.Player2Display.IsEnabled = false;
            }
        }

        private void StartGame_Click(object sender, RoutedEventArgs e)
        {
            MainPageData dc = (MainPageData)this.DataContext;
            GameDifficulty gd = GameDifficulty.Easy;
            if(rdoEasy.IsChecked==true)
            {
                gd = GameDifficulty.Easy;
            }
            else if (rdoMedium.IsChecked==true)
            {
                gd = GameDifficulty.Medium;
            }
            else if (rdoHard.IsChecked==true)
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
