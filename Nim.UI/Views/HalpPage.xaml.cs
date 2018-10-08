using System;
using System.Collections.Generic;
using System.IO;
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
    /// Interaction logic for Halp.xaml
    /// </summary>
    public partial class Halp : Page
    {

        public Halp()
        {
            InitializeComponent();
        }

        private void HowTo_Click(object sender, RoutedEventArgs e)
        {
            var allDaRules = File.ReadAllText("Resources/DaRules.txt");
            MessageBox.Show(allDaRules);
        }

        private void Devinfo_Click(object sender, RoutedEventArgs e)
        {
            var devstuff = File.ReadAllText("Resources/DeveloperInfo.txt");
            MessageBox.Show(devstuff);
        }
    }
}
