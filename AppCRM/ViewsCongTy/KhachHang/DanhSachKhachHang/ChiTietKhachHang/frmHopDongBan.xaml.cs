using AppCRM.Class.HopDong;
using AppCRM.Views.KhachHang.NhomKhachHang;
using AppCRM.ViewsCongTy.KhachHang.DanhSachKhachHang.ChiTietKhachHang;
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

namespace AppCRM.Views.KhachHang.DanhSachKhachHang.ChiTietKhachHang
{
    /// <summary>
    /// Interaction logic for frmHopDongBan.xaml
    /// </summary>
    public partial class frmHopDongBan : Page
    {
        private List<clsHopDongBan.Datum> lstHDB = new List<clsHopDongBan.Datum>();
        private string IdKhachHang = "";
        private frmTrangChuSauDangNhapCongTy frmMain;
        private Model.APIEntity.DataLogin_Company data;
        private List<clsNhanVien.Item> lstNhanVien = new List<clsNhanVien.Item>();
        private string TenKH = "";
        private string EmailKH = "";
        private string SDTKh = "";
        private List<Class.clsPhongBanThuocCongTy.Item> lstPhongBan = new List<Class.clsPhongBanThuocCongTy.Item>();
        public frmHopDongBan(frmTrangChuSauDangNhapCongTy frm, string idKH, Model.APIEntity.DataLogin_Company dt, List<clsNhanVien.Item> lstNv, List<Class.clsPhongBanThuocCongTy.Item> lstPb, string tenkh, string emailkh, string sdtkh)
        {
            InitializeComponent();
            data = dt;
            LoadDLHopDongBan(idKH);
            IdKhachHang = idKH;
            TenKH = tenkh;
            EmailKH = emailkh;
            SDTKh = sdtkh;
            frmMain = frm;
            lstNhanVien = lstNv;
            lstPhongBan = lstPb;
        }


        public void LoadDLHopDongBan(string IdKH)
        {
            try
            {
                lstHDB = new List<clsHopDongBan.Datum>();
                //dgv.Items.Clear();
                using (HttpClient httpClient = new HttpClient())
                {
                    //string url = Properties.Resources.URL + "listGroupCustomer";
                    string url = $"https://crm.timviec365.vn/ApiWinform/listContractCus?customerId={IdKH}";
                    httpClient.DefaultRequestHeaders.Add("Authorization", AppCRM.Properties.Settings.Default.Token);
                    var kq = httpClient.GetAsync(url);
                    clsHopDongBan.Root api = JsonConvert.DeserializeObject<clsHopDongBan.Root>(kq.Result.Content.ReadAsStringAsync().Result);
                    if (api != null)
                    {
                        foreach (var item in api.data)
                        {
                            if (item.status == "0")
                            {
                                item.status = "Chưa gửi";
                            }
                            else
                            {
                                item.status = "Đã gửi";
                            }
                            lstHDB.Add(item);
                            for (int i = 1; i <= lstHDB.Count; i++)
                            {
                                item.stt = i.ToString();
                            }
                        }
                        dgv.ItemsSource = lstHDB;
                    }
                }
            }
            catch (Exception ex)
            {
                var check = ex.Message;
            }
        }
        private void btnTaoHopDong_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            Views.KhachHang.DanhSachKhachHang.ChiTietKhachHang.frmThemHopDongBan frm = new Views.KhachHang.DanhSachKhachHang.ChiTietKhachHang.frmThemHopDongBan(frmMain, IdKhachHang, lstNhanVien, lstPhongBan, data, TenKH, EmailKH, SDTKh);
            pnlHienThi.Children.Clear();
            object content = frm.Content;
            frm.Content = null;
            //frm.Close();
            pnlHienThi.Children.Add(content as UIElement);
        }

        private void textGuiHD_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            string IdHD = "";
            clsHopDongBan.Datum hdb = (clsHopDongBan.Datum)dgv.SelectedItem;
            if (hdb != null)
            {
                IdHD = hdb.id;
            }
            frmGuiHopDong frm = new frmGuiHopDong(data, lstNhanVien, lstPhongBan, IdHD, frmMain, IdKhachHang, TenKH, EmailKH, SDTKh);
            pnlHienThi.Children.Clear();
            object content = frm.Content;
            frm.Content = null;
            //frm.Close();
            pnlHienThi.Children.Add(content as UIElement);
        }

        private void btnXoaHD_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            string IdHD = "";
            clsHopDongBan.Datum hdb = (clsHopDongBan.Datum)dgv.SelectedItem;
            if (hdb != null)
            {
                IdHD = hdb.id;
            }
            frmMain.pnlShowPopup.Children.Add(new ViewsCongTy.KhachHang.DanhSachKhachHang.ChiTietKhachHang.Popup.PopUpXoaHopDong(IdHD, data, this, IdKhachHang));
        }

        private void textTenHDB_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            string IdHDB = "";
            clsHopDongBan.Datum hdb = (clsHopDongBan.Datum)dgv.SelectedItem;
            if (hdb != null)
            {
                IdHDB = hdb.id;
            }
            frmChiTietHopDongBan frm = new frmChiTietHopDongBan(IdHDB, frmMain, data, lstNhanVien, lstPhongBan, IdKhachHang, TenKH, EmailKH, SDTKh);
            pnlHienThi.Children.Clear();
            object content = frm.Content;
            frm.Content = null;
            //frm.Close();
            pnlHienThi.Children.Add(content as UIElement);
        }
    }
}
