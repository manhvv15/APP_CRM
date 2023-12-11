using AppCRM.Class;
using AppCRM.Class.HopDong;
using AppCRM.Views.KhachHang.NhomKhachHang;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.IO;
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

namespace AppCRM.ViewsNhanVien.KhachHang.DanhSachKhachHang.ChiTietKhachHang
{
    /// <summary>
    /// Interaction logic for frmChiTietHopDongBan.xaml
    /// </summary>
    public partial class frmChiTietHopDongBan : Page
    {
        private frmThanhMenuDoc frmMain;
        private string IdHopDong = "";
        private Model.APIEntity.DataLogin_Employee data;
        private List<clsNhanVien.Item> lstNhanVien;
        private List<clsPhongBanThuocCongTy.Item> lstPhongBan;
        private string IdKhachHang = "";
        private string TenKH = "";
        private string EmailKH = "";
        private string SDTKh = "";
        public frmChiTietHopDongBan(string IdHD, frmThanhMenuDoc frm, Model.APIEntity.DataLogin_Employee dt, List<clsNhanVien.Item> lstnv, List<clsPhongBanThuocCongTy.Item> lstpb, string Idkh, string Tenkh, string Emaikh, string sdtKH)
        {
            InitializeComponent();
            frmMain = frm;
            IdHopDong = IdHD;
            data = dt;
            lstNhanVien = lstnv;
            lstPhongBan = lstpb;
            IdKhachHang = Idkh;
            TenKH = Tenkh;
            EmailKH = Emaikh;
            SDTKh = sdtKH;
            LoadFileHDB(IdHD);
        }
        List<BitmapImage> lstBI = new List<BitmapImage>();
        private void LoadFileHDB(string Id)
        {
            lstBI = new List<BitmapImage>();
            using (RestClient restclient = new RestClient(new Uri("https://crm.timviec365.vn/ApiWinform/detailContractCus")))
            {
                RestRequest request = new RestRequest();
                request.Method = Method.Post;
                request.AlwaysMultipartFormData = true;
                request.AddHeader("Authorization", AppCRM.Properties.Settings.Default.TokenNhanVien);
                request.AddParameter("id_contract", Id);
                
                RestResponse resAlbum = restclient.Execute(request);
                var b = resAlbum.Content;
                Class.DanhSachKhachHang.clsChiTietHopDongBan.Root receivedInfo = JsonConvert.DeserializeObject<Class.DanhSachKhachHang.clsChiTietHopDongBan.Root>(b);
                if (receivedInfo.data != null)
                {

                    foreach (string b64 in receivedInfo.data)
                    {
                        string[] ChiTiet = b64.Split(new[] { "data:image/png;base64," }, StringSplitOptions.None);
                        string Base64 = ChiTiet[ChiTiet.Length - 1];
                        byte[] binaryData = Convert.FromBase64String(Base64);
                        BitmapImage bi = new BitmapImage();
                        bi.BeginInit();
                        bi.StreamSource = new MemoryStream(binaryData);
                        bi.EndInit();
                        lstBI.Add(bi);
                    }
                    lsvImageHD.ItemsSource = lstBI;
                }
            }
        }

        private void lsvImageHD_PreviewMouseWheel(object sender, MouseWheelEventArgs e)
        {
            scrollImageHD.ScrollToVerticalOffset(scrollImageHD.VerticalOffset - e.Delta);
        }

        private void btnGuiHopDong_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            frmGuiHopDong frm = new frmGuiHopDong(data, lstNhanVien, lstPhongBan, IdHopDong, frmMain, IdKhachHang, TenKH, EmailKH, SDTKh);
            pnlHienThi.Children.Clear();
            object content = frm.Content;
            frm.Content = null;
            //frm.Close();
            pnlHienThi.Children.Add(content as UIElement);
        }
    }
}
