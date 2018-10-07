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

namespace Nim.UI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private string toPage = "";

        public MainWindow()
        {
            InitializeComponent();
        }
        private void Options_Click(object sender, RoutedEventArgs e)
        {
            //MessageBox.Show("Options");
        }
        private void Halp_Click(object sender, RoutedEventArgs e)
        {
            //MessageBox.Show("Halp");
            Halp halp = new Halp();
            halp.CheckClick += value =>
            halp.DataContext = this.DataContext;
            this.frameToHoldThePages.Navigate(halp);
            
        }
        private void Main_Click(object sender, RoutedEventArgs e)
        {
            MainMenu mainMenu = new MainMenu();
            mainMenu.CheckClick += value => toPage = value;
            MessageBox.Show(toPage);
            mainMenu.DataContext = this.DataContext;
            this.frameToHoldThePages.Navigate(mainMenu);
        }

        private void Close_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            var page =  new GamePage();
            page.DataContext = this.DataContext;
            this.frameToHoldThePages.Navigate(page);
        }
    }
}
