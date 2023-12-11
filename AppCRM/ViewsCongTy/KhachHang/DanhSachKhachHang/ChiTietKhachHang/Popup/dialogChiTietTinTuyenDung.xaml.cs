using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
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

namespace AppCRM.Views.KhachHang.DanhSachKhachHang.ChiTietKhachHang.Popup
{
    /// <summary>
    /// Interaction logic for dialogChiTietTinTuyenDung.xaml
    /// </summary>
    public partial class dialogChiTietTinTuyenDung : UserControl
    {
        private string IdTinDang = "";
        private string NoiDungTin = "";
        private List<string> lstChiTiet = new List<string>();
        public dialogChiTietTinTuyenDung(string Id,string NoiDung)
        {
            InitializeComponent();
            this.DataContext = this;
            IdTinDang = Id;
            NoiDungTin = NoiDung;
            string[] ChiTiet = NoiDung.Split(new[] { "<br>" }, StringSplitOptions.None);
            lstChiTiet = new List<string>();
            foreach(string ct in ChiTiet)
            {
                lstChiTiet.Add(ct);
            }
            lsvNoiDung.ItemsSource = lstChiTiet;
        }

        private void btnDong_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
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
