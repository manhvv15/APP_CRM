using AppCRM.Model.APIEntity;
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
using System.Windows.Shapes;

namespace AppCRM.Views.KhachHang.TinhTrangKhachHang
{
    /// <summary>
    /// Interaction logic for frmThemMoiTinhTrangKH.xaml
    /// </summary>
    public partial class frmThemMoiTinhTrangKH : Window
    {
        private Model.APIEntity.DataLogin_Company _dt;

        public DataLogin_Company Dt { get => _dt; set => _dt = value; }
        private string MaTinhTrang = "";
        public frmThemMoiTinhTrangKH(DataLogin_Company data, string TieuDe, clsTinhTrangKhachHang.Datum tinhtrang)
        {
            InitializeComponent();
            textTieuDe.Text = TieuDe;
            Dt = data;
            if(textTieuDe.Text=="Chỉnh sửa tình trạng khách hàng")
            {
                MaTinhTrang = tinhtrang.stt_id;
                tb_TenTinhTrang.Text = tinhtrang.stt_name;
            }
            else
            {
                tb_TenTinhTrang.Text = "";
            }
            
        }

        private void btnHuy_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            this.Close();
        }

        private void btnClose_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            this.Close();
        }

        private void btnDongY_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if(textTieuDe.Text=="Thêm mới tình trạng khách hàng")
            {
                using (WebClient httpClient = new WebClient())
                {
                    try
                    {
                        httpClient.Headers.Add("Authorization", Dt.token);
                        httpClient.QueryString.Add("name", tb_TenTinhTrang.Text);

                        httpClient.UploadValuesCompleted += (sender1, e1) =>
                        {
                            
                            this.Close();
                            //APIRequestContact receiveInfo = JsonConvert.DeserializeObject(UnicodeEncoding.UTF8.GetString(e.Result));
                            //if (receiveInfo.data != null)
                            //{
                            //    DataChat.Socket.DeleteContact(contactId, userId);
                            //}
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
                            
                        };
                        httpClient.UploadValuesAsync(new Uri(Properties.Resources.URL + "updateStatusCustomer"), "POST", httpClient.QueryString);
                        //frmTinhTrangKhachHang frm = new frmTinhTrangKhachHang(Dt);
                        //frm.LoadLaiDanhSachTinhTrangKhachHang();
                        this.Close();
                    }
                    catch
                    {
                    }
                }
            }
        }

    }
}
