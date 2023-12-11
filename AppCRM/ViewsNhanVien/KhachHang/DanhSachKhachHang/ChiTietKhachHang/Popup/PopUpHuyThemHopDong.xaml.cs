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

namespace AppCRM.ViewsNhanVien.KhachHang.DanhSachKhachHang.ChiTietKhachHang.Popup
{
    /// <summary>
    /// Interaction logic for PopUpHuyThemHopDong.xaml
    /// </summary>
    public partial class PopUpHuyThemHopDong : UserControl
    {
        private frmThemMoiHopDongBan frmThemMoi;
        public PopUpHuyThemHopDong(frmThemMoiHopDongBan frm)
        {
            InitializeComponent();
            frmThemMoi = frm;
        }

        private void Rectangle_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.Visibility = Visibility.Collapsed;
        }

        private void btnHuy_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            this.Visibility = Visibility.Collapsed;
        }

        private void btnDongY_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            this.Visibility = Visibility.Collapsed;
            frmThemMoi.HuyThemHopDong();
            
        }

        private void btnClose_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            this.Visibility = Visibility.Collapsed;
        }
    }
}
