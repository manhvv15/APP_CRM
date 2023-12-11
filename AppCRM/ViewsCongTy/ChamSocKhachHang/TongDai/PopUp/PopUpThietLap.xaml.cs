using AppCRM.Views.ChamSocKhachHang.TongDai;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
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

namespace AppCRM.ViewsCongTy.ChamSocKhachHang.TongDai.PopUp
{
    /// <summary>
    /// Interaction logic for PopUpThietLap.xaml
    /// </summary>
    public partial class PopUpThietLap : UserControl
    {
        private List<clsNhanVienThuocPhongBan.Item> lst = new List<clsNhanVienThuocPhongBan.Item>();

        public List<clsNhanVienThuocPhongBan.Item> Lst { get => lst; set => lst = value; }
        private Model.APIEntity.DataLogin_Employee data;

        private string IdNhanVien = "";
        private frmQuanLyLine frmQLLine;
        public PopUpThietLap(frmQuanLyLine frm, Model.APIEntity.DataLogin_Employee dt, string SoLine, string IdNV, string passW)
        {
            InitializeComponent();
            data = dt;
            frmQLLine = frm;
            tb_SDT.Text = SoLine;
            tb_MatKhau.Password = passW;
            LoadDLXepHangKH(IdNV);
        }

        private void Rectangle_MouseDown(object sender, MouseButtonEventArgs e)
        {

        }

        private async void LoadDLXepHangKH(string Id)
        {
            try
            {
                using (HttpClient httpClient = new HttpClient())
                {
                    //string url = Properties.Resources.URL + "listGroupCustomer";
                    string url = "https://chamcong.24hpay.vn/service/list_all_employee_of_company.php?id_com=3312";
                    httpClient.DefaultRequestHeaders.Add("Authorization", data.token);
                    var kq = await httpClient.GetAsync(url);
                    clsNhanVienThuocPhongBan.Root api = JsonConvert.DeserializeObject<clsNhanVienThuocPhongBan.Root>(kq.Content.ReadAsStringAsync().Result);
                    if (api.data != null)
                    {
                        foreach (var item in api.data.items)
                        {
                            Lst.Add(item);
                            cboNhanVienPhuTrach.Items.Add("(" + item.ep_id + ")" + item.ep_name + " - " + item.dep_name);
                        }
                        foreach (var nv in Lst)
                        {
                            if (nv.ep_id == Id)
                            {
                                cboNhanVienPhuTrach.Text = "(" + Id + ")" + nv.ep_name + " - " + nv.dep_name;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                var check = ex.Message;
            }
        }
        private void btnHuy_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            this.Visibility = Visibility.Collapsed;
        }

        private void btnClose_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            this.Visibility = Visibility.Collapsed;
        }

        private void btnThietLap_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            using (WebClient httpClient = new WebClient())
            {
                try
                {
                    httpClient.Headers.Add("Authorization", data.token);
                    httpClient.QueryString.Add("extension", tb_SDT.Text);
                    if (cboNhanVienPhuTrach.Text != "")
                    {
                        string[] Id = cboNhanVienPhuTrach.Text.Split(Convert.ToChar(")"));
                        string IdNhanVien1 = Id[Id.Length - 2];
                        string[] Id1 = IdNhanVien1.Split(Convert.ToChar("("));
                        string IdNhanVien = Id1[Id1.Length - 1];
                        httpClient.QueryString.Add("emp_id", IdNhanVien);
                    }
                    httpClient.QueryString.Add("password", tb_MatKhau.Password);
                    foreach (clsNhanVienThuocPhongBan.Item nv in Lst)
                    {
                        if (cboNhanVienPhuTrach.Text == nv.ep_id)
                        {
                            httpClient.QueryString.Add("emp_name", nv.ep_name);
                        }
                    }
                    httpClient.UploadValuesCompleted += (sender1, e1) =>
                    {
                        this.Visibility = Visibility.Collapsed;
                        frmQLLine.LoadDLSoLineNguoiPhuTrach(data);
                    };
                    httpClient.UploadValuesAsync(new Uri(Properties.Resources.URL + "settingEmpLine"), "POST", httpClient.QueryString);
                    //frmTinhTrangKhachHang frm = new frmTinhTrangKhachHang(Dt);
                    //frm.LoadLaiDanhSachTinhTrangKhachHang();

                }
                catch
                {
                }
            }
        }
    }
}
