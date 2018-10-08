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
            
        }
        private void Halp_Click(object sender, RoutedEventArgs e)
        {
            
        }
        private void Main_Click(object sender, RoutedEventArgs e)
        {
            MainMenu mainMenu = new MainMenu();
            mainMenu.CheckClick += value =>
            {
                ChangePage(value);
            };
        }

        private void Difficulty_Click(object sender, RoutedEventArgs e)
        {
            DifficultyPage difficulty = new DifficultyPage();
            difficulty.CheckClick += value =>
            {
                ChangePage(value);
            };
        }

        private void Close_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            // Change to MainMenu after testing is done.
            var page = new MainMenu();
            page.CheckClick += value =>
            {
                ChangePage(value);
            };
            page.DataContext = this.DataContext;
            this.frameToHoldThePages.Navigate(page);
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
                default:
                    break;
            }
        }
    }
}
