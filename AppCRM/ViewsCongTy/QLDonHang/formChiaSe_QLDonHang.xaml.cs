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

namespace AppCRM.Views.QLDonHang
{
    /// <summary>
    /// Interaction logic for formChiaSe_QLDonHang.xaml
    /// </summary>
    public partial class formChiaSe_QLDonHang : Page
    {
        public formChiaSe_QLDonHang()
        {
            InitializeComponent();
        }

        private void Border_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            formPhongBan.Visibility = Visibility.Visible;
            formNV.Visibility = Visibility.Collapsed;
        }

        private void Border_MouseLeftButtonDown_1(object sender, MouseButtonEventArgs e)
        {
            formPhongBan.Visibility = Visibility.Collapsed;
            formNV.Visibility = Visibility.Visible;
        }
    }
}
