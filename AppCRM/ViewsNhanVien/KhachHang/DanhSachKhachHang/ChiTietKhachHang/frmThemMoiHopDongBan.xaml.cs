using AppCRM.Class.HopDong;
using AppCRM.Views.HopDong;
using AppCRM.Views.KhachHang.NhomKhachHang;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using static AppCRM.Views.HopDong.clsDanhSachAnhHopDong;

namespace AppCRM.ViewsNhanVien.KhachHang.DanhSachKhachHang.ChiTietKhachHang
{
    /// <summary>
    /// Interaction logic for frmThemMoiHopDongBan.xaml
    /// </summary>
    public partial class frmThemMoiHopDongBan : Page
    {
        private List<clsHopDong.Datum> lstHopDong = new List<clsHopDong.Datum>();
        private string IdKhachHang = "";
        private string IdFile = "";
        private string PathFile = "";
        private frmThanhMenuDoc frmMain;
        private List<clsNhanVien.Item> lstNhanVien = new List<clsNhanVien.Item>();
        private List<Class.clsPhongBanThuocCongTy.Item> lstPhongBan = new List<Class.clsPhongBanThuocCongTy.Item>();
        private Model.APIEntity.DataLogin_Employee data;
        private string TenKH = "";
        private string EmailKH = "";
        private string SDTKhachHang = "";
        public frmThemMoiHopDongBan(frmThanhMenuDoc frm, string IdKH, List<clsNhanVien.Item> lstNV, Model.APIEntity.DataLogin_Employee dt, List<Class.clsPhongBanThuocCongTy.Item> lstPB, string Tenkh, string Emailkh, string sdt)
        {
            InitializeComponent();
            this.DataContext = this;
            TenKH = Tenkh;
            EmailKH = Emailkh;
            SDTKhachHang = sdt;
            IdKhachHang = IdKH;
            frmMain = frm;
            lstNhanVien = lstNV;
            lstPhongBan = lstPB;
            data = dt;
            LoadDLHopDong();
        }
        private List<clsHopDong.Datum> lstHD = new List<clsHopDong.Datum>();
        private void LoadDLHopDong()
        {
            try
            {
                lstHopDong = new List<clsHopDong.Datum>();
                //dgv.Items.Clear();
                using (HttpClient httpClient = new HttpClient())
                {
                    //string url = Properties.Resources.URL + "listGroupCustomer";
                    string url = "https://crm.timviec365.vn/ApiWinform/listContract";
                    httpClient.DefaultRequestHeaders.Add("Authorization", AppCRM.Properties.Settings.Default.TokenNhanVien);
                    var kq = httpClient.GetAsync(url);
                    clsHopDong.Root api = JsonConvert.DeserializeObject<clsHopDong.Root>(kq.Result.Content.ReadAsStringAsync().Result);
                    if (api != null)
                    {
                        foreach (var item in api.data)
                        {
                            
                            lstHD.Add(item);
                            cboHopDong.Items.Add(item.id + "-" + item.name);

                        }
                        
                    }
                }
            }
            catch (Exception ex)
            {
                var check = ex.Message;
            }
        }
        private string IdHD = "";
        private List<string> lstTruongCu = new List<string>();
        private List<string> lstViTriThayDoi = new List<string>();
        public List<clsTruongThayTheFormHD.List> lstList = new List<clsTruongThayTheFormHD.List>();
        private void cboHopDong_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            lstList = new List<clsTruongThayTheFormHD.List>();
            var select = sender as System.Windows.Controls.ComboBox;
            string name = select.SelectedItem as string;
            string[] Name1 = name.Split(Convert.ToChar("-"));
            IdHD = Name1[0];
            
            using (HttpClient httpClient = new HttpClient())
            {
                //string url = Properties.Resources.URL + "listGroupCustomer";
                string url = $"https://crm.timviec365.vn/ApiWinform/infoFieldContract?contractId={IdHD}&customerId={IdKhachHang}";
                httpClient.DefaultRequestHeaders.Add("Authorization", AppCRM.Properties.Settings.Default.TokenNhanVien);
                var kq = httpClient.GetAsync(url);
                clsTruongThayTheFormHD.Root api = JsonConvert.DeserializeObject<clsTruongThayTheFormHD.Root>(kq.Result.Content.ReadAsStringAsync().Result);
                if (api != null)
                {
                    IdFile = api.data.id_file;
                    PathFile = api.data.path;
                    foreach (var item in api.data.lists)
                    {
                        if (item.new_field == "@Tên công ty")
                        {
                            item.tuthaythe = TenKH;
                        }
                        else if (item.new_field == "@Địa chỉ")
                        {
                            item.tuthaythe = "null";
                        }
                        else if (item.new_field == "@Gmail")
                        {
                            item.tuthaythe = EmailKH;
                        }
                        else if (item.new_field == "@Số điện thoại")
                        {
                            item.tuthaythe = SDTKhachHang;
                        }
                        else if (item.new_field == "@ngày")
                        {
                            item.tuthaythe = DateTime.Now.Day.ToString();
                        }
                        else if (item.new_field == "@tháng")
                        {
                            item.tuthaythe = DateTime.Now.Month.ToString();
                        }
                        else if (item.new_field == "@năm")
                        {
                            item.tuthaythe = DateTime.Now.Year.ToString();
                        }
                        else if (item.new_field == "@Mã số thuế")
                        {
                            item.tuthaythe = "null";
                        }
                        else if (item.new_field == "@Tên chuyên viên")
                        {
                            item.tuthaythe = data.ep_name;
                        }
                        else if (item.new_field == "@Số điện thoại chuyên viên")
                        {
                            item.tuthaythe = data.ep_phone;
                        }
                        lstList.Add(item);
                        lstTruongCu.Add(item.old_field);
                        lstViTriThayDoi.Add(item.index_field);
                    }
                    lsvTruongTD.ItemsSource = lstList;
                }
            }
        }
        List<BitmapImage> lstBI = new List<BitmapImage>();
        private List<string> lstTrangThai = new List<string>();
        private void bd_XemTruocHopDong_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            lstTrangThai = new List<string>();
            foreach(clsTruongThayTheFormHD.List lst in lstList)
            {
                if (lst.tuthaythe == null || lst.tuthaythe == "")
                {
                    lst.trangthai = "Vui lòng nhập từ thay thế";
                    lstList = lstList.ToList();
                    lsvTruongTD.ItemsSource = lstList;
                    lstTrangThai.Add(lst.trangthai);
                    lstBI.Clear();
                }
                else
                {
                    lst.trangthai = "";
                }
            }
            if (lstTrangThai.Count == 0)
            {
                List<string> lstTuSeThayThe = new List<string>();
                foreach (clsTruongThayTheFormHD.List lst in lstList)
                {
                    lst.trangthai = "";
                    lstTuSeThayThe.Add(lst.tuthaythe);
                }
                lstList = lstList.ToList();
                lsvTruongTD.ItemsSource = lstList;
                string TuSeThayThe = "";
                foreach (string str in lstTuSeThayThe)
                {
                    TuSeThayThe = TuSeThayThe + str + ",";
                }
                TuSeThayThe = TuSeThayThe.Remove(TuSeThayThe.Length - 1);
                string TruongCu = "";
                foreach (string str in lstTruongCu)
                {
                    TruongCu = TruongCu + str + ",";
                }
                TruongCu = TruongCu.Remove(TruongCu.Length - 1);
                string ViTri = "";
                foreach (string str in lstViTriThayDoi)
                {
                    ViTri = ViTri + str + "|";
                }
                ViTri = ViTri.Remove(ViTri.Length - 1);

                lstBI = new List<BitmapImage>();
                using (RestClient restclient = new RestClient(new Uri("https://crm.timviec365.vn/ApiWinform/addContractCus")))
                {
                    RestRequest request = new RestRequest();
                    request.Method = Method.Post;
                    request.AlwaysMultipartFormData = true;
                    request.AddHeader("Authorization", AppCRM.Properties.Settings.Default.TokenNhanVien);
                    request.AddParameter("customerId", IdKhachHang);
                    request.AddParameter("contractId", IdHD);
                    request.AddParameter("id_file", IdFile);
                    request.AddParameter("path", PathFile);
                    request.AddParameter("text_old", TruongCu);
                    request.AddParameter("text_index", ViTri);
                    request.AddParameter("view", "1");
                    request.AddParameter("text_new", TuSeThayThe);
                    RestResponse resAlbum = restclient.Execute(request);
                    var b = resAlbum.Content;
                    clsXemTruocHopDong.Root receivedInfo = JsonConvert.DeserializeObject<clsXemTruocHopDong.Root>(b);
                    if (receivedInfo.data != null)
                    {

                        foreach (string b64 in receivedInfo.data.img_org_base64)
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



        }
        private string IdTruongThayThe = "";
        private string TuCanThayThe = "";
        private string TuSeThayThe = "";
        
        private void textThayTheTu_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            clsTruongThayTheFormHD.List TruongThayThe = (clsTruongThayTheFormHD.List)lsvTruongTD.SelectedItem;
            if (TruongThayThe != null)
            {
                IdTruongThayThe = TruongThayThe.id;
                TuCanThayThe = TruongThayThe.old_field;
                TuSeThayThe = TruongThayThe.tuthaythe;
            }
            frmMain.pnlShowPopup.Children.Add(new Popup.PopUpTuThayThe(this, IdTruongThayThe, TuCanThayThe, TuSeThayThe));
        }

        private void lsvTruongTD_PreviewMouseWheel(object sender, MouseWheelEventArgs e)
        {
            frmMain.scrollMain.ScrollToVerticalOffset(frmMain.scrollMain.VerticalOffset - e.Delta);
        }

        private void lsvImageHD_PreviewMouseWheel(object sender, MouseWheelEventArgs e)
        {
            frmMain.scrollMain.ScrollToVerticalOffset(frmMain.scrollMain.VerticalOffset - e.Delta);
        }

        private void bd_Luu_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            lstTrangThai = new List<string>();
            foreach (clsTruongThayTheFormHD.List lst in lstList)
            {
                if (lst.tuthaythe == null || lst.tuthaythe == "")
                {
                    lst.trangthai = "Vui lòng nhập từ thay thế";
                    lstList = lstList.ToList();
                    lsvTruongTD.ItemsSource = lstList;
                    lstTrangThai.Add(lst.trangthai);
                    lstBI.Clear();
                }
                else
                {
                    lst.trangthai = "";
                }
            }
            if (lstTrangThai.Count == 0)
            {
                List<string> lstTuSeThayThe = new List<string>();
                foreach (clsTruongThayTheFormHD.List lst in lstList)
                {
                    lst.trangthai = "";
                    lstTuSeThayThe.Add(lst.tuthaythe);
                }
                lstList = lstList.ToList();
                lsvTruongTD.ItemsSource = lstList;
                string TuSeThayThe = "";
                foreach (string str in lstTuSeThayThe)
                {
                    TuSeThayThe = TuSeThayThe + str + ",";
                }
                TuSeThayThe = TuSeThayThe.Remove(TuSeThayThe.Length - 1);
                string TruongCu = "";
                foreach (string str in lstTruongCu)
                {
                    TruongCu = TruongCu + str + ",";
                }
                TruongCu = TruongCu.Remove(TruongCu.Length - 1);
                string ViTri = "";
                foreach (string str in lstViTriThayDoi)
                {
                    ViTri = ViTri + str + "|";
                }
                ViTri = ViTri.Remove(ViTri.Length - 1);
                using (WebClient httpClient = new WebClient())
                {
                    try
                    {
                        httpClient.Headers.Add("Authorization", AppCRM.Properties.Settings.Default.TokenNhanVien);
                        httpClient.QueryString.Add("customerId", IdKhachHang);
                        httpClient.QueryString.Add("contractId", IdHD);
                        httpClient.QueryString.Add("id_file", IdFile);
                        httpClient.QueryString.Add("path", PathFile);
                        httpClient.QueryString.Add("text_old", TruongCu);
                        httpClient.QueryString.Add("text_index", ViTri);
                        httpClient.QueryString.Add("text_new", TuSeThayThe);
                        httpClient.UploadValuesCompleted += (sender1, e1) =>
                        {
                            frmHopDongBan frm = new frmHopDongBan(frmMain, IdKhachHang, data, lstNhanVien, lstPhongBan, TenKH, SDTKhachHang, EmailKH);
                            pnlHienThi.Children.Clear();
                            object content = frm.Content;
                            frm.Content = null;
                            pnlHienThi.Children.Add(content as UIElement);
                            frmMain.pnlShowPopup.Children.Add(new Tool.PopUpThongBaoThanhCong("Thêm mới hợp đồng thành công!"));
                        };
                        httpClient.UploadValuesAsync(new Uri(Properties.Resources.URL + "addContractCus"), "POST", httpClient.QueryString);
                    }
                    catch
                    {
                    }
                }
                //lstBI = new List<BitmapImage>();
                //using (RestClient restclient = new RestClient(new Uri("https://crm.timviec365.vn/ApiWinform/addContractCus")))
                //{
                //    RestRequest request = new RestRequest();
                //    request.Method = Method.Post;
                //    request.AlwaysMultipartFormData = true;
                //    request.AddHeader("Authorization", AppCRM.Properties.Settings.Default.TokenNhanVien);
                //    request.AddParameter("customerId", IdKhachHang);
                //    request.AddParameter("contractId", IdHD);
                //    request.AddParameter("id_file", IdFile);
                //    request.AddParameter("path", PathFile);
                //    request.AddParameter("text_old", TruongCu);
                //    request.AddParameter("text_index", ViTri);
                //    request.AddParameter("view", "1");
                //    request.AddParameter("text_new", TuSeThayThe);
                //    RestResponse resAlbum = restclient.Execute(request);
                //    var b = resAlbum.Content;
                //    clsXemTruocHopDong.Root receivedInfo = JsonConvert.DeserializeObject<clsXemTruocHopDong.Root>(b);
                //    if (receivedInfo.data != null)
                //    {

                //        foreach (string b64 in receivedInfo.data.img_org_base64)
                //        {
                //            string[] ChiTiet = b64.Split(new[] { "data:image/png;base64," }, StringSplitOptions.None);
                //            string Base64 = ChiTiet[ChiTiet.Length - 1];
                //            byte[] binaryData = Convert.FromBase64String(Base64);
                //            BitmapImage bi = new BitmapImage();
                //            bi.BeginInit();
                //            bi.StreamSource = new MemoryStream(binaryData);
                //            bi.EndInit();
                //            lstBI.Add(bi);
                //        }
                //        lsvImageHD.ItemsSource = lstBI;
                //    }
                //}
            }
        }

        private void bd_Huy_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            frmMain.pnlShowPopup.Children.Add(new Popup.PopUpHuyThemHopDong(this));
        }
        public void HuyThemHopDong()
        {
            frmHopDongBan frm = new frmHopDongBan(frmMain, IdKhachHang, data, lstNhanVien, lstPhongBan, TenKH, SDTKhachHang, EmailKH);
            pnlHienThi.Children.Clear();
            object content = frm.Content;
            frm.Content = null;
            pnlHienThi.Children.Add(content as UIElement);

        }
    }
}
