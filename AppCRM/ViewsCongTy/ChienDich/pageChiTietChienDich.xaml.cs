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

namespace AppCRM.Views.ChienDich
{
    /// <summary>
    /// Interaction logic for pageChiTietChienDich.xaml
    /// </summary>
    public partial class pageChiTietChienDich : Window
    {
        public pageChiTietChienDich()
        {
            InitializeComponent();
        }
        private void PathTurnOn(object sender, MouseButtonEventArgs e)
        {
            iconOff.Visibility = Visibility.Collapsed;
            iconOn.Visibility = Visibility.Visible;
        }
        private void PathTurnOff(object sender, MouseButtonEventArgs e)
        {
            iconOff.Visibility = Visibility.Visible;
            iconOn.Visibility = Visibility.Collapsed;
        }
    }
}
