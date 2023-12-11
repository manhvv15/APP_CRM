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
using System.Windows.Shapes;

namespace AppCRM.Views.ChamSocKhachHang.KhaoSat
{
    /// <summary>
    /// Interaction logic for frmXoaKhaoSatMessagebox.xaml
    /// </summary>
    public partial class frmXoaKhaoSatMessagebox : Window
    {
        public frmXoaKhaoSatMessagebox()
        {
            InitializeComponent();
        }

        private void btnHuy_MouseEnter(object sender, MouseEventArgs e)
        {
            btnHuy.Background = Brushes.BlueViolet;
            tblHuy.Foreground = Brushes.White;
        }

        private void btnHuy_MouseLeave(object sender, MouseEventArgs e)
        {
            btnHuy.Background = Brushes.White;
            tblHuy.Foreground = Brushes.BlueViolet;
        }

        private void btnHuy_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            this.Close();
        }

        private void btnClose_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            this.Close();
        }
    }
}
