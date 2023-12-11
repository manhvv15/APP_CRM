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
    /// Interaction logic for ChonLoaiCauHoi.xaml
    /// </summary>
    public partial class ChonLoaiCauHoi : Page
    {
        frmChinhSuaKhaoSat DataPop;
        public ChonLoaiCauHoi(frmChinhSuaKhaoSat chamsocKH)
        {
            InitializeComponent();
            this.DataContext = this;
            DataPop = chamsocKH;

        }

        private void tuluan_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            DataPop.frame_LoaiCauHoi.Visibility = DataPop.tracNghiem.Visibility = Visibility.Collapsed;
            DataPop.lsvTracNghiem.Visibility = Visibility.Collapsed;
            DataPop.lsvTuLuan.Visibility = Visibility.Visible;
            DataPop.tuLuan.Visibility = Visibility.Visible;
            DataPop.dpnThem.Visibility = Visibility.Collapsed;
            DataPop.lst.Clear();
        }

        private void tracnghiem_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            DataPop.frame_LoaiCauHoi.Visibility = DataPop.tuLuan.Visibility = Visibility.Collapsed;
            DataPop.lsvTracNghiem.Visibility = Visibility.Visible;
            DataPop.lsvTuLuan.Visibility = Visibility.Collapsed;
            DataPop.tracNghiem.Visibility = Visibility.Visible;
            DataPop.dpnThem.Visibility = Visibility.Visible;
            DataPop.lst.Clear();
        }
    }
}
