using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
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

namespace AppCRM.Views.CaiDat.ChiaSeKhachHang
{
    /// <summary>
    /// Interaction logic for frmChiaSeKhachHang.xaml
    /// </summary>
    public partial class frmChiaSeKhachHang : Window
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        public frmChiaSeKhachHang()
        {
            InitializeComponent();
            this.DataContext = this;
            List<KhachHang> lstKH = new List<KhachHang>();
            lstKH.Add(new KhachHang() { STT = "1", TenNhanVien = "22",  PhongBan = "55" });
            lstKH.Add(new KhachHang() { STT = "2", TenNhanVien = "22", PhongBan = "55" });
            lstKH.Add(new KhachHang() { STT = "3", TenNhanVien = "22", PhongBan = "55" });
            lstKH.Add(new KhachHang() { STT = "4", TenNhanVien = "22", PhongBan = "55" });
            lstKH.Add(new KhachHang() { STT = "5", TenNhanVien = "22", PhongBan = "55" });

            dgv.ItemsSource = lstKH;
            txtTongSoDoiTuong.Text = lstKH.Count.ToString();
        }
        
        private void TurnOn_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            isOn = isOn == 0 ? 1 : 0;
        }

        private void TurnOff_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            isOn = isOn == 1 ? 0 : 1;
        }
        public class KhachHang
        {
            public string STT { get; set; }
            public string TenNhanVien { get; set; }
            public string PhongBan { get; set; }
        }
        private int _isOn;
        public int isOn { get => _isOn; set { _isOn = value; OnPropertyChanged(); } }

        private void textNhanVien_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            frmDanhSachDoiTuongNvChiaSe frm = new frmDanhSachDoiTuongNvChiaSe();
            pnlHienThi.Children.Clear();
            object content = frm.Content;
            frm.Content = null;
            //frm.Close();
            pnlHienThi.Children.Add(content as UIElement);
        }
    }
}
