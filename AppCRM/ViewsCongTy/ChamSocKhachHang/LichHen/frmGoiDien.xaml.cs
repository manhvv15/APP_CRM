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

namespace AppCRM.Views.ChamSocKhachHang.LichHen
{
    /// <summary>
    /// Interaction logic for frmGoiDien.xaml
    /// </summary>
    public partial class frmGoiDien : Window
    {
        public frmGoiDien()
        {
            InitializeComponent();
        }

        private void btnClose_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            this.Close();
        }

        private void btnHuy_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            this.Close();
        }

        private void tblPhongTo_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            tblPhongTo.Visibility = Visibility.Collapsed;
            tblThuNho.Visibility = Visibility.Visible;
            frmTroLyKD.Visibility = Visibility.Visible;
        }

        private void tblThuNho_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            tblPhongTo.Visibility = Visibility.Visible;
            tblThuNho.Visibility = Visibility.Collapsed;
            frmTroLyKD.Visibility = Visibility.Collapsed;
        }
    }
}
