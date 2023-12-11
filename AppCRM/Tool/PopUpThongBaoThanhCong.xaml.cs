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

namespace AppCRM.Tool
{
    /// <summary>
    /// Interaction logic for PopUpThongBaoThanhCong.xaml
    /// </summary>
    public partial class PopUpThongBaoThanhCong : UserControl
    {
        private ViewsNhanVien.KhachHang.DanhSachKhachHang.ChiTietKhachHang.frmThemMoiHopDongBan frmThemHopDongBan;
        public PopUpThongBaoThanhCong(string ThongBao)
        {
            InitializeComponent();
            textThongBao.Text = ThongBao;
            //frmThemHopDongBan = frm;
        }

        private void btnDong_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            //frmThemHopDongBan.HuyThemHopDong();
            this.Visibility = Visibility.Collapsed;
        }

        private void Rectangle_MouseDown(object sender, MouseButtonEventArgs e)
        {
            //frmThemHopDongBan.HuyThemHopDong();
            this.Visibility = Visibility.Collapsed;
        }
    }
}
