using Nim.UI.Views;
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

namespace Nim.UI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private void Options_Click(object sender, RoutedEventArgs e)
        {
            ChangePage(Pages.Settings);
        }
        private void Halp_Click(object sender, RoutedEventArgs e)
        {
            ChangePage(Pages.Halp);
        }
        private void Main_Click(object sender, RoutedEventArgs e)
        {
            ChangePage(Pages.MainMenu);
        }

        private void Difficulty_Click(object sender, RoutedEventArgs e)
        {
            ChangePage(Pages.Difficulty);
        }

        private void Close_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            ChangePage(Pages.MainMenu);
        }

        private void ChangePage(Pages options)
        {
            switch (options)

            {
                case Pages.Difficulty:
                    var difficulty = new DifficultyPage();
                    difficulty.CheckClick += value =>
                    {
                        ChangePage(value);
                    };
                    difficulty.DataContext = this.DataContext;
                    this.frameToHoldThePages.Navigate(difficulty);
                    break;
                case Pages.Halp:
                    Halp halp = new Halp();
                    halp.DataContext = this.DataContext;
                    this.frameToHoldThePages.Navigate(halp);
                    break;
                case Pages.Settings:
                    var settings = new Settings();
                    settings.DataContext = this.DataContext;
                    this.frameToHoldThePages.Navigate(settings);
                    break;
                case Pages.Game:
                    var game = new GamePage();
                    game.DataContext = this.DataContext;
                    game.CheckClick += value =>
                    {
                        ChangePage(value);
                    };
                    this.frameToHoldThePages.Navigate(game);
                    break;
                case Pages.MainMenu:
                    MainMenu mainMenu = new MainMenu();
                    mainMenu.CheckClick += value =>
                    {
                        ChangePage(value);
                    };
                    mainMenu.DataContext = this.DataContext;
                    this.frameToHoldThePages.Navigate(mainMenu);
                    break;
                case Pages.GameOver:
                    var gameOver = new GameOver();
                    gameOver.CheckClick += value =>
                    {
                        ChangePage(value);
                    };
                    gameOver.DataContext = this.DataContext;
                    this.frameToHoldThePages.Navigate(gameOver);
                    break;
                default:
                    break;
            }
        }
    }
}
