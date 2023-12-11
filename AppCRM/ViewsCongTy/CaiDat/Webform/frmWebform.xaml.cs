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

namespace AppCRM.Views.CaiDat.Webform
{
    /// <summary>
    /// Interaction logic for frmWebform.xaml
    /// </summary>
    public partial class frmWebform : Window
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        public frmWebform()
        {
            InitializeComponent();
            List<webforms> lstWf = new List<webforms>();
            lstWf.Add(new webforms { STT = "1", TenForm = "Form khách hàng", TrangThai = "Đang hoạt động", NguoiTao = "Công ty Hưng Hà", ThoiGianCapNhat = "10/10/2020" });
            lstWf.Add(new webforms { STT = "2", TenForm = "Form khách hàng", TrangThai = "Đang hoạt động", NguoiTao = "Công ty Hưng Hà", ThoiGianCapNhat = "10/10/2020" });
            lstWf.Add(new webforms { STT = "3", TenForm = "Form khách hàng", TrangThai = "Đang hoạt động", NguoiTao = "Công ty Hưng Hà", ThoiGianCapNhat = "10/10/2020" });
            lstWf.Add(new webforms { STT = "4", TenForm = "Form khách hàng", TrangThai = "Đang hoạt động", NguoiTao = "Công ty Hưng Hà", ThoiGianCapNhat = "10/10/2020" });
            lstWf.Add(new webforms { STT = "5", TenForm = "Form khách hàng", TrangThai = "Đang hoạt động", NguoiTao = "Công ty Hưng Hà", ThoiGianCapNhat = "10/10/2020" });
            lstWf.Add(new webforms { STT = "6", TenForm = "Form khách hàng", TrangThai = "Đang hoạt động", NguoiTao = "Công ty Hưng Hà", ThoiGianCapNhat = "10/10/2020" });
            lstWf.Add(new webforms { STT = "7", TenForm = "Form khách hàng", TrangThai = "Đang hoạt động", NguoiTao = "Công ty Hưng Hà", ThoiGianCapNhat = "10/10/2020" });
            lstWf.Add(new webforms { STT = "6", TenForm = "Form khách hàng", TrangThai = "Đang hoạt động", NguoiTao = "Công ty Hưng Hà", ThoiGianCapNhat = "10/10/2020" });
            lstWf.Add(new webforms { STT = "7", TenForm = "Form khách hàng", TrangThai = "Đang hoạt động", NguoiTao = "Công ty Hưng Hà", ThoiGianCapNhat = "10/10/2020" });
            lstWf.Add(new webforms { STT = "6", TenForm = "Form khách hàng", TrangThai = "Đang hoạt động", NguoiTao = "Công ty Hưng Hà", ThoiGianCapNhat = "10/10/2020" });
            lstWf.Add(new webforms { STT = "7", TenForm = "Form khách hàng", TrangThai = "Đang hoạt động", NguoiTao = "Công ty Hưng Hà", ThoiGianCapNhat = "10/10/2020" });
            dgv.ItemsSource = lstWf;
        }
        public class webforms
        {
            public string STT { get; set; }
            public string TenForm { get; set; }
            public string TrangThai { get; set; }
            public string NguoiTao { get; set; }
            public string ThoiGianCapNhat { get; set; }
        }
        private int _isOn;
        public int isOn { get => _isOn; set { _isOn = value; OnPropertyChanged(); } }

        private void btnIon_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            isOn = isOn == 0 ? 1 : 0;
        }

        private void btnIOff_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            isOn = isOn == 1 ? 0 : 1;
        }

        private void btnThemMoi_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            frmThemMoiWebform frm = new frmThemMoiWebform();
            pnlHienThi.Children.Clear();
            object content = frm.Content;
            frm.Content = null;
            frm.Close();
            pnlHienThi.Children.Add(content as UIElement);
        }
    }
}
