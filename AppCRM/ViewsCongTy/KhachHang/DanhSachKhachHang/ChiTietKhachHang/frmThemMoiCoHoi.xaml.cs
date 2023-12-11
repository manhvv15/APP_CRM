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
    /// Interaction logic for frmThemMoiCoHoi.xaml
    /// </summary>
    public partial class frmThemMoiCoHoi : Page
    {
        public frmThemMoiCoHoi()
        {
            InitializeComponent();
            List<string> loaich = new List<string>() { "33", "44", "55" };
            cboLoaiCH.ItemsSource = loaich;
        }
    }
}
