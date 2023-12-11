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

namespace AppCRM.Views.KhachHang.DanhSachKhachHang.ChiTietKhachHang
{
    /// <summary>
    /// Interaction logic for frmLichSuDonHang.xaml
    /// </summary>
    public partial class frmLichSuDonHang : Window
    {
        public frmLichSuDonHang()
        {
            InitializeComponent();
            //List<LichSu> lst = new List<LichSu>();
            //lst.Add(new LichSu { STT = "1", SoDonHang = "DH-01", TrangThai = "Chờ duyệt", DienGiai = "Tốt", GiaTri = "10.000.000", NguoiThucHien = "Hoàng", NgayDatHang = "1/1/2020", TinhTrangThanhToan = "Đã thanh toán", TinhTrangGiaoHang = "Đã giao hàng" });
            //lst.Add(new LichSu { STT = "2", SoDonHang = "DH-02", TrangThai = "Đã duyệt", DienGiai = "Tốt", GiaTri = "5.000.000", NguoiThucHien = "Hoàng", NgayDatHang = "1/1/2020", TinhTrangThanhToan = "Đã thanh toán", TinhTrangGiaoHang = "Đã giao hàng" });
            //lst.Add(new LichSu { STT = "3", SoDonHang = "DH-03", TrangThai = "Chờ duyệt", DienGiai = "Tốt", GiaTri = "4.000.000", NguoiThucHien = "Hoàng", NgayDatHang = "1/1/2020", TinhTrangThanhToan = "Đã thanh toán", TinhTrangGiaoHang = "Đã giao hàng" });
            //lst.Add(new LichSu { STT = "4", SoDonHang = "DH-04", TrangThai = "Đã duyệt", DienGiai = "Tốt", GiaTri = "14.000.000", NguoiThucHien = "Hoàng", NgayDatHang = "1/1/2020", TinhTrangThanhToan = "Đã thanh toán", TinhTrangGiaoHang = "Đã giao hàng" });
            //dgv.ItemsSource = lst;
            //txtTongSoDong.Text = lst.Count.ToString();
        }
        //public class LichSu
        //{
        //    public string STT { get; set; }
        //    public string SoDonHang { get; set; }
        //    public string TrangThai { get; set; }
        //    public string DienGiai { get; set; }
        //    public string GiaTri { get; set; }
        //    public string NguoiThucHien { get; set; }
        //    public string NgayDatHang { get; set; }
        //    public string TinhTrangThanhToan { get; set; }
        //    public string TinhTrangGiaoHang { get; set; }
        //}

        private void btnThemMoiLSDH_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            frmThemMoiLichSuDonHang frm = new frmThemMoiLichSuDonHang();
            pnlHienThi.Children.Clear();
            object content = frm.Content;
            frm.Content = null;
            frm.Close();
            pnlHienThi.Children.Add(content as UIElement);
        }
    }
}
