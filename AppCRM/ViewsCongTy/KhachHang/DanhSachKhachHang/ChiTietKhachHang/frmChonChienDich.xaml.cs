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
    /// Interaction logic for frmChonChienDich.xaml
    /// </summary>
    public partial class frmChonChienDich : UserControl
    {
        public frmChonChienDich()
        {
            InitializeComponent();
            //List<test> lst = new List<test>();
            //lst.Add(new test { STT = "1", TenChienDich = "Hoàng", TinhTrang = "Tạm dừng", Loai = "10/10/0000", NgayBatDau = "50.000.000", NgayKetThuc = "Hoàng", NguoiPhuTrach = "333" });
            //lst.Add(new test { STT = "2", TenChienDich = "Hoàng", TinhTrang = "Đang diễn ra", Loai = "10/10/0000", NgayBatDau = "50.000.000", NgayKetThuc = "Hoàng", NguoiPhuTrach = "333" });
            //lst.Add(new test { STT = "3", TenChienDich = "Hoàng", TinhTrang = "Đã kết thúc", Loai = "10/10/0000", NgayBatDau = "50.000.000", NgayKetThuc = "Hoàng", NguoiPhuTrach = "333" });
            //datagrid1.ItemsSource = lst;
            
        }
        public class test
        {
            public string STT { get; set; }
            public string TenChienDich { get; set; }
            public string TinhTrang { get; set; }
            public string Loai { get; set; }
            public string NgayBatDau { get; set; }
            public string NgayKetThuc { get; set; }
            public string NguoiPhuTrach { get; set; }
        }

        private void btnHuy_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            this.Visibility = Visibility.Collapsed;
        }

        private void btnClose_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            this.Visibility = Visibility.Collapsed;
        }

        private void Rectangle_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.Visibility = Visibility.Collapsed;
        }
    }
}
