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
using System.Windows.Shapes;

namespace AppCRM.Views.KhachHang.DanhSachKhachHang.ChiTietKhachHang
{
    /// <summary>
    /// Interaction logic for frmThemMoiGhiChu.xaml
    /// </summary>
    public partial class frmThemMoiGhiChu : UserControl
    {
        private string IdKH = "";
        private string IdGhiChu = "";
        private frmGhiChu frmGC;
        public frmThemMoiGhiChu(string IdKhachHang, string TieuDe, string IdNote, string ContentNote, frmGhiChu frm)
        {
            InitializeComponent();
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
            if(textTieuDe.Text=="Thêm mới ghi chú")
            {
                using (RestClient restclient = new RestClient(new Uri("https://crm.timviec365.vn/ApiWinform/addOrUpdateNoteCus")))
                {
                    try
                    {
                        RestRequest request = new RestRequest();
                        request.Method = Method.Post;
                        request.AlwaysMultipartFormData = true;
                        request.AddHeader("Authorization", AppCRM.Properties.Settings.Default.Token);
                        request.AddParameter("customerId", IdKH);
                        request.AddParameter("noteContent", tb_NoiDungGhiChu.Text);

                        RestResponse resAlbum = restclient.Execute(request);
                        var b = resAlbum.Content;
                        this.Visibility = Visibility.Collapsed;
                        frmGC.LoadDLGhiChu();
                        //frmGhiChu frm = new frmGhiChu(IdKH);
                        //pnlHienThi.Children.Clear();
                        //object Content = frm.Content;
                        //frm.Content = null;
                        //frm.Close();
                        //pnlHienThi.Children.Add(Content as UIElement);
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
                        request.AddHeader("Authorization", AppCRM.Properties.Settings.Default.Token);
                        request.AddParameter("noteId", IdGhiChu);
                        request.AddParameter("customerId", IdKH);
                        request.AddParameter("noteContent", tb_NoiDungGhiChu.Text);

                        RestResponse resAlbum = restclient.Execute(request);
                        var b = resAlbum.Content;
                        frmGC.LoadDLGhiChu();
                        this.Visibility = Visibility.Collapsed;
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
