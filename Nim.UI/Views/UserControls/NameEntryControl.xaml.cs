using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;

namespace Nim.UI.Views.UserControls
{
    /// <summary>
    /// Interaction logic for NameEntryControl.xaml
    /// </summary>
    public partial class NameEntryControl : UserControl
    {
        public string PName
        {
            get { return (string)GetValue(PNameProperty); }
            set { SetValue(PNameProperty, value); }
        }

        // Using a DependencyProperty as the backing store for PName.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty PNameProperty =
            DependencyProperty.Register("PName", typeof(string), typeof(NameEntryControl), new PropertyMetadata(""));

        public NameEntryControl()
        {
            InitializeComponent();
            DataContext = this;
        }
    }
}
