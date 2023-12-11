using AppCRM.Views.KhachHang.NhomKhachHang;
using Newtonsoft.Json;
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

namespace AppCRM.Tool
{
    /// <summary>
    /// Interaction logic for ComboboxNhanVienThuocPhongBan.xaml
    /// </summary>
    public partial class ComboboxNhanVienThuocPhongBan : UserControl
    {
        private List<clsNhanVien.Item> lstNhanVien = new List<clsNhanVien.Item>();
        public ComboboxNhanVienThuocPhongBan()
        {
            InitializeComponent();
            
            LoadDataNhanVien();
            
        }

        private void Border_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            LoadDanhSachNhanVienTheoPhongBan();
            if (cbx.IsDropDownOpen == false)
            {
                cbx.IsDropDownOpen = true;
            }
            else
            {
                cbx.IsDropDownOpen = false;
            }
            return;
        }
        public void LoadDataNhanVien(/*Model.APIEntity.DataLogin_Company data*/)
        {
            try
            {
                //cbx.Items.Clear();
                using (WebClient webClient = new WebClient())
                {
                    //string url = Properties.Resources.URL + "listGroupCustomer";
                    string url = "https://chamcong.24hpay.vn/service/list_all_employee_of_company.php";
                    webClient.Headers.Add("Authorization", AppCRM.Properties.Settings.Default.Token);
                    var kq = webClient.UploadValues(new Uri(url), webClient.QueryString);
                    clsNhanVien.Root api = JsonConvert.DeserializeObject<clsNhanVien.Root>(UnicodeEncoding.UTF8.GetString(kq));
                    if (api.data != null)
                    {
                        foreach (var item in api.data.items)
                        {
                            lstNhanVien.Add(item);
                        }
                        //lst = lst.ToList();
                    }
                }
            }
            catch (Exception ex)
            {
                var check = ex.Message;
            }

        }
        public void LoadDanhSachNhanVienTheoPhongBan()
        {
            cbx.Items.Clear();
            foreach (clsNhanVien.Item item in lstNhanVien)
            {
                foreach (string idPhong in clsBien.listIDPhongBan)
                {
                    if (idPhong == item.dep_id)
                    {
                        cbx.Items.Add("(" + item.ep_id + ")" + item.ep_name + "-" + item.dep_name);
                    }
                }
            }
        }

        private void cbx_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cbx.IsDropDownOpen == true)
            {
                text.Text = "";
                string[] Ten = new string[2];
                Ten = cbx.SelectedItem.ToString().Split(Convert.ToChar(":"));
                string Ten2 = Ten[Ten.Length - 1];
                text.Text = Ten2;
                string[] Id0 = Ten2.Split(Convert.ToChar(")"));
                string Id1 = Id0[Id0.Length - 2];
                string[] Id2 = Id1.Split(Convert.ToChar("("));
                string Id3 = Id2[Id2.Length - 1];
                clsBien.listIDNhanVien.Add(Id3);
                string TenNV = Id0[Id0.Length - 1];
                string[] TenNV1 = TenNV.Split(Convert.ToChar("-"));
                Class.clsNhanVienThuocPhongBan nhanvien = new Class.clsNhanVienThuocPhongBan();
                nhanvien.TenNhanVien = TenNV1[0];
                nhanvien.PhongBan = TenNV1[TenNV1.Length - 1];
                clsBien.lstNhanVienPB.Add(nhanvien);
                //ThemMoi.listEmployee.Add(Id3);
                //frmThemMoiNhomKhachHang frm = new frmThemMoiNhomKhachHang(null, null);
                //frm.dgv.Items.Add("Hoàng");
                //LoadDSIdNhanVien();
            }

            //cbx.IsDropDownOpen = false;
            //cbx.Text = "";
            //string[] Ten = new string[2];
            //Ten = cbx.SelectedItem.ToString().Split(Convert.ToChar(":"));
            //string ten2 = Ten[Ten.Length - 1];
            //text.Text = ten2;
        }

    }
}
