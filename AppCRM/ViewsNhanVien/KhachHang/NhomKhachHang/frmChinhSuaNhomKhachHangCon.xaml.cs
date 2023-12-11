using AppCRM.Views.KhachHang.NhomKhachHang;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net;
using System.Net.Http;
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

namespace AppCRM.Views.KhachHang.NhomKhachHangNhanVien
{
    /// <summary>
    /// Interaction logic for frmChinhSuaNhomKhachHangConNhanVien.xaml
    /// </summary>
    public partial class frmChinhSuaNhomKhachHangConNhanVien : Page,INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        private List<clsNhomKhachHang> lst = new List<clsNhomKhachHang>();
        private Model.APIEntity.DataLogin_Employee dt = new Model.APIEntity.DataLogin_Employee();
        private string IdNhomKhachHang = "";
        frmThanhMenuDoc frmMain;
        public frmChinhSuaNhomKhachHangConNhanVien(Model.APIEntity.DataLogin_Employee data, string IdNhomCon, string TenNhomCon, string MoTaCon, string NhomKHCha, frmThanhMenuDoc frm)
        {
            InitializeComponent();
            dt = data;
            frmMain = frm;
            LoadDataNhomKHCha(data);
            IdNhomKhachHang = IdNhomCon;
            tb_TenNhomKhachHang.Text = TenNhomCon;
            tb_MoTa.Text = MoTaCon;
            foreach (clsNhomKhachHang cls in lst)
            {
                if (NhomKHCha == cls.gr_id)
                {
                    cboNhomKhachHangCha.Text = cls.gr_name;
                }
            }
        }
        private string IdNhomKhachHangCha = "";
        private void bd_Luu_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            foreach (clsNhomKhachHang nhomKHCha in lst)
            {
                if (cboNhomKhachHangCha.Text == nhomKHCha.gr_name)
                {
                    IdNhomKhachHangCha = nhomKHCha.gr_id;
                }
                else if (cboNhomKhachHangCha.Text == "Chọn nhóm khách hàng cha")
                {
                    IdNhomKhachHangCha = "0";
                }
            }
            using (WebClient httpClient = new WebClient())
            {
                try
                {
                    httpClient.Headers.Add("Authorization", dt.token);
                    httpClient.QueryString.Add("id", IdNhomKhachHang);
                    httpClient.QueryString.Add("name", tb_TenNhomKhachHang.Text);
                    httpClient.QueryString.Add("description", tb_MoTa.Text);
                    httpClient.QueryString.Add("groupParent", IdNhomKhachHangCha);


                    httpClient.UploadValuesCompleted += (sender1, e1) =>
                    {
                        frmNhomKhachHangNhanVien frm = new frmNhomKhachHangNhanVien(dt,frmMain);
                        pnlHienThi.Children.Clear();
                        object content = frm.Content;
                        frm.Content = null;
                        //frm.Close();
                        pnlHienThi.Children.Add(content as UIElement);

                    };
                    httpClient.UploadValuesAsync(new Uri(Properties.Resources.URL + "updateGroupCustomer"), "POST", httpClient.QueryString);

                }
                catch
                {
                }
            }
        }
        private void LoadDataNhomKHCha(Model.APIEntity.DataLogin_Employee data)
        {
            try
            {
                using (HttpClient httpClient = new HttpClient())
                {
                    //string url = Properties.Resources.URL + "listGroupCustomer";
                    string url = "https://crm.timviec365.vn/ApiWinform/listGroupCustomer";
                    httpClient.DefaultRequestHeaders.Add("Authorization", data.token);
                    var kq = httpClient.GetAsync(url);
                    RootCustomer api = JsonConvert.DeserializeObject<RootCustomer>(kq.Result.Content.ReadAsStringAsync().Result);
                    if (api != null)
                    {

                        foreach (var item in api.data)
                        {
                            lst.Add(item);
                            cboNhomKhachHangCha.Items.Add(item.gr_name);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                var check = ex.Message;
            }
        }
    }
}
