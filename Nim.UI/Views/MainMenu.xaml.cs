﻿using System;
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
    /// Interaction logic for MainMenu.xaml
    /// </summary>
    public partial class MainMenu : Page
    {
        public event Action<Pages> CheckClick;
        public MainMenu()
        {
            InitializeComponent();
        }

        private void SinglePlayerClick(object sender, RoutedEventArgs e)
        {
            MainPageData dc = (MainPageData)this.DataContext;
            dc.GameController.Type = Lib.Enums.GameType.OnePlayer;
            CheckClick(Pages.Difficulty);
        }

        private void TwoPlayerClick(object sender, RoutedEventArgs e)
        {
            MainPageData dc = (MainPageData)this.DataContext;
            dc.GameController.Type = Lib.Enums.GameType.TwoPlayer;
            CheckClick(Pages.Difficulty);
        }

        private void HalpClick(object sender, RoutedEventArgs e)
        {
            CheckClick(Pages.Halp);
        }

        private void SettingsClick(object sender, RoutedEventArgs e)
        {
            CheckClick(Pages.Settings);
        }

        private void CloseClick(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
