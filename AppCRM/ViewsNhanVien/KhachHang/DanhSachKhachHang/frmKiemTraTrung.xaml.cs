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

namespace AppCRM.Views.KhachHang.DanhSachKhachHangNhanVien
{
    /// <summary>
    /// Interaction logic for frmKiemTraTrungNhanVien.xaml
    /// </summary>
    public partial class frmKiemTraTrungNhanVien : Page
    {
        public frmKiemTraTrungNhanVien(string TenKhachHang)
        {
            InitializeComponent();
            tb_TenKH.Text = TenKhachHang;
        }
        private void radioTatCa_Checked(object sender, RoutedEventArgs e)
        {
            textDieuKien1.Text = "Và";
            textDieuKien2.Text = "Và";
            textDieuKien3.Text = "Và";
        }

        private void radioBatKy_Checked(object sender, RoutedEventArgs e)
        {
            textDieuKien1.Text = "Hoặc";
            textDieuKien2.Text = "Hoặc";
            textDieuKien3.Text = "Hoặc";
        }

        private void Border_MouseEnter(object sender, MouseEventArgs e)
        {
            MessageBox.Show("ok");
        }
    }
}
