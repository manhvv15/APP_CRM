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

namespace AppCRM.Views.ChamSocKhachHang.KhaoSat
{
    /// <summary>
    /// Interaction logic for frmKhaoSat.xaml
    /// </summary>
    public partial class frmKhaoSat : Window
    {
        public frmKhaoSat()
        {
            InitializeComponent();
            //List<KhaoSat> lstKS = new List<KhaoSat>();
            //lstKS.Add(new KhaoSat { TenKhaoSat = "Khảo sát 1", Url = "24h.com.vn", MoTa = "Đẹp", ThoiGianTao = "12/12/3333", DoiTuongThucHien = "Hoàng", NguoiTao = "Hoàng" });
            //lstKS.Add(new KhaoSat { TenKhaoSat = "Khảo sát 2", Url = "24h.com.vn", MoTa = "Đẹp", ThoiGianTao = "12/12/3333", DoiTuongThucHien = "Hoàng", NguoiTao = "Hoàng" });
            //lstKS.Add(new KhaoSat { TenKhaoSat = "Khảo sát 3", Url = "24h.com.vn", MoTa = "Đẹp", ThoiGianTao = "12/12/3333", DoiTuongThucHien = "Hoàng", NguoiTao = "Hoàng" });
            //lstKS.Add(new KhaoSat { TenKhaoSat = "Khảo sát 4", Url = "24h.com.vn", MoTa = "Đẹp", ThoiGianTao = "12/12/3333", DoiTuongThucHien = "Hoàng", NguoiTao = "Hoàng" });
            //lstKS.Add(new KhaoSat { TenKhaoSat = "Khảo sát 5", Url = "24h.com.vn", MoTa = "Đẹp", ThoiGianTao = "12/12/3333", DoiTuongThucHien = "Hoàng", NguoiTao = "Hoàng" });
            //lstKS.Add(new KhaoSat { TenKhaoSat = "Khảo sát 6", Url = "24h.com.vn", MoTa = "Đẹp", ThoiGianTao = "12/12/3333", DoiTuongThucHien = "Hoàng", NguoiTao = "Hoàng" });
            //lstKS.Add(new KhaoSat { TenKhaoSat = "Khảo sát 7", Url = "24h.com.vn", MoTa = "Đẹp", ThoiGianTao = "12/12/3333", DoiTuongThucHien = "Hoàng", NguoiTao = "Hoàng" });
            //lstKS.Add(new KhaoSat { TenKhaoSat = "Khảo sát 5", Url = "24h.com.vn", MoTa = "Đẹp", ThoiGianTao = "12/12/3333", DoiTuongThucHien = "Hoàng", NguoiTao = "Hoàng" });
            //lstKS.Add(new KhaoSat { TenKhaoSat = "Khảo sát 6", Url = "24h.com.vn", MoTa = "Đẹp", ThoiGianTao = "12/12/3333", DoiTuongThucHien = "Hoàng", NguoiTao = "Hoàng" });
            //lstKS.Add(new KhaoSat { TenKhaoSat = "Khảo sát 7", Url = "24h.com.vn", MoTa = "Đẹp", ThoiGianTao = "12/12/3333", DoiTuongThucHien = "Hoàng", NguoiTao = "Hoàng" });
            //dgv.ItemsSource = lstKS;
        }
        //public class KhaoSat
        //{
        //    public string TenKhaoSat { get; set; }
        //    public string Url { get; set; }
        //    public string MoTa { get; set; }
        //    public string ThoiGianTao { get; set; }
        //    public string DoiTuongThucHien { get; set; }
        //    public string NguoiTao { get; set; }
        //}

        private void btnThemMoi_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            ThemMoiKhaoSat frm = new ThemMoiKhaoSat();
            pnlHienThi.Children.Clear();
            object content = frm.Content;
            frm.Content = null;
            frm.Close();
            pnlHienThi.Children.Add(content as UIElement);
        }
    }
}
