using RestSharp;
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

namespace AppCRM.Views.KhachHang.DanhSachKhachHangNhanVien.ChiTietKhachHangNhanVien
{
    /// <summary>
    /// Interaction logic for frmThemMoiGhiChuNhanVien.xaml
    /// </summary>
    public partial class frmThemMoiGhiChuNhanVien : UserControl
    {
        private string IdKH = "";
        private string IdGhiChu = "";
        private Model.APIEntity.DataLogin_Employee data;
        private frmGhiChuNhanVien frmGC;
        public frmThemMoiGhiChuNhanVien(frmGhiChuNhanVien frm, string IdKhachHang, string TieuDe, string IdNote, string ContentNote, Model.APIEntity.DataLogin_Employee dt)
        {
            InitializeComponent();
            data = dt;
            frmGC = frm;
            textTieuDe.Text = TieuDe;
            IdKH = IdKhachHang;
            IdGhiChu = IdNote;
            if (textTieuDe.Text == "Chỉnh sửa ghi chú")
            {
                tb_NoiDungGhiChu.Text = ContentNote;
            }
            else
            {

            }
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
            if (textTieuDe.Text == "Thêm mới ghi chú")
            {
                using (RestClient restclient = new RestClient(new Uri("https://crm.timviec365.vn/ApiWinform/addOrUpdateNoteCus")))
                {
                    try
                    {
                        RestRequest request = new RestRequest();
                        request.Method = Method.Post;
                        request.AlwaysMultipartFormData = true;
                        request.AddHeader("Authorization", data.token);
                        request.AddParameter("customerId", IdKH);
                        request.AddParameter("noteContent", tb_NoiDungGhiChu.Text);
                        RestResponse resAlbum = restclient.Execute(request);
                        var b = resAlbum.Content;
                        this.Visibility = Visibility.Collapsed;
                        frmGC.LoadDLGhiChu();
                    }
                    catch
                    {
                    }
                }

            }
            else
            {
                using (RestClient restclient = new RestClient(new Uri("https://crm.timviec365.vn/ApiWinform/addOrUpdateNoteCus")))
                {
                    try
                    {
                        RestRequest request = new RestRequest();
                        request.Method = Method.Post;
                        request.AlwaysMultipartFormData = true;
                        request.AddHeader("Authorization", data.token);
                        request.AddParameter("noteId", IdGhiChu);
                        request.AddParameter("customerId", IdKH);
                        request.AddParameter("noteContent", tb_NoiDungGhiChu.Text);

                        RestResponse resAlbum = restclient.Execute(request);
                        var b = resAlbum.Content;
                        this.Visibility = Visibility.Collapsed;
                        frmGC.LoadDLGhiChu();
                    }
                    catch
                    {
                    }
                }

            }
        }

        private void Rectangle_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.Visibility = Visibility.Collapsed;
        }
    }
}
