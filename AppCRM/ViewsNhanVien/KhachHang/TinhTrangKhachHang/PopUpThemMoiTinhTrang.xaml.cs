using AppCRM.Model.APIEntity;
using AppCRM.Views.KhachHang.TinhTrangKhachHang;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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

namespace AppCRM.Views.KhachHang.TinhTrangKhachHangNhanVien
{
    /// <summary>
    /// Interaction logic for PopUpThemMoiTinhTrangNhanVien.xaml
    /// </summary>
    public partial class PopUpThemMoiTinhTrangNhanVien : UserControl
    {
        private Model.APIEntity.DataLogin_Employee _dt;
        private frmTinhTrangKhachHangNhanVien frmTT;
        public DataLogin_Employee Dt { get => _dt; set => _dt = value; }
        private string MaTinhTrang = "";
        public PopUpThemMoiTinhTrangNhanVien(frmTinhTrangKhachHangNhanVien frm, DataLogin_Employee data, string TieuDe, clsTinhTrangKhachHang.Datum tinhtrang)
        {
            InitializeComponent();
            textTieuDe.Text = TieuDe;
            Dt = data;
            frmTT = frm;
            if (textTieuDe.Text == "Chỉnh sửa tình trạng khách hàng")
            {
                MaTinhTrang = tinhtrang.stt_id;
                tb_TenTinhTrang.Text = tinhtrang.stt_name;
            }
            else
            {
                tb_TenTinhTrang.Text = "";
            }
        }

        private void Rectangle_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.Visibility = Visibility.Collapsed;
        }

        private void btnClose_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            this.Visibility = Visibility.Collapsed;
        }

        private void btnHuy_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            this.Visibility = Visibility.Collapsed;
        }

        private void btnDongY_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (textTieuDe.Text == "Thêm mới tình trạng khách hàng")
            {
                using (WebClient httpClient = new WebClient())
                {
                    try
                    {
                        httpClient.Headers.Add("Authorization", Dt.token);
                        httpClient.QueryString.Add("name", tb_TenTinhTrang.Text);

                        httpClient.UploadValuesCompleted += (sender1, e1) =>
                        {

                            this.Visibility = Visibility.Collapsed;
                            frmTT.LoadLaiDanhSachTinhTrangKhachHang();
                        };
                        httpClient.UploadValuesAsync(new Uri(Properties.Resources.URL + "addStatusCustomer"), "POST", httpClient.QueryString);
                    }
                    catch
                    {
                    }
                }
            }
            else
            {
                using (WebClient httpClient = new WebClient())
                {
                    try
                    {
                        httpClient.Headers.Add("Authorization", Dt.token);
                        httpClient.QueryString.Add("id", MaTinhTrang);
                        httpClient.QueryString.Add("name", tb_TenTinhTrang.Text);

                        //httpClient.QueryString.Add("listIdDep", null);
                        //httpClient.QueryString.Add("listIdEpl", null);

                        httpClient.UploadValuesCompleted += (sender1, e1) =>
                        {
                            frmTT.LoadLaiDanhSachTinhTrangKhachHang();
                        };
                        httpClient.UploadValuesAsync(new Uri(Properties.Resources.URL + "updateStatusCustomer"), "POST", httpClient.QueryString);
                        this.Visibility = Visibility.Collapsed;
                    }
                    catch
                    {
                    }
                }
            }
        }

    }
}
