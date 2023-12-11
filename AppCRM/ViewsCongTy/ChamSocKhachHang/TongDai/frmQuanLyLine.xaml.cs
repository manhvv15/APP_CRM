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

namespace AppCRM.Views.ChamSocKhachHang.TongDai
{
    /// <summary>
    /// Interaction logic for frmQuanLyLine.xaml
    /// </summary>
    public partial class frmQuanLyLine : Page
    {
        private List<clsSoLine.Datum> lstSoLine = new List<clsSoLine.Datum>();

        public List<clsSoLine.Datum> LstSoLine { get => lstSoLine; set => lstSoLine = value; }
        private Model.APIEntity.DataLogin_Employee data;
        private frmThanhMenuDoc Main;
        public frmQuanLyLine(frmThanhMenuDoc main, List<clsSoLine.Datum> lst,Model.APIEntity.DataLogin_Employee dt)
        {
            InitializeComponent();
            Main = main;
            data = dt;
            dgv.ItemsSource = clsBien.lstSoLine;
            
        }
        
        private void textSua_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            Main.pnlShowPopup.Children.Add(new ViewsCongTy.ChamSocKhachHang.TongDai.PopUp.PopUpThietLap(this, data, Soline, IdNhanVien, Pass));
            //frmThietLap frm = new frmThietLap(data, Soline, IdNhanVien, Pass);
            //frm.ShowDialog();
            LoadDLSoLineNguoiPhuTrach(data);
        }
        public void LoadDLSoLineNguoiPhuTrach(Model.APIEntity.DataLogin_Employee data)
        {
            clsBien.lstSoLine = new List<clsSoLine.Datum>();
            try
            {
                using (HttpClient httpClient = new HttpClient())
                {
                    //string url = Properties.Resources.URL + "listGroupCustomer";
                    string url = "https://crm.timviec365.vn/ApiWinform/listLine";
                    httpClient.DefaultRequestHeaders.Add("Authorization", data.token);
                    var kq = httpClient.GetAsync(url);
                    clsSoLine.Root api = JsonConvert.DeserializeObject<clsSoLine.Root>(kq.Result.Content.ReadAsStringAsync().Result);
                    if (api != null)
                    {
                        foreach (var item in api.data)
                        {
                            clsBien.lstSoLine.Add(item);
                            for (int i = 1; i <= clsBien.lstSoLine.Count; i++)
                            {
                                item.stt = i.ToString();
                            }
                        }
                        dgv.ItemsSource = clsBien.lstSoLine;
                    }
                }
            }
            catch (Exception ex)
            {
                var check = ex.Message;
            }
        }
        private string Soline = "";
        private string IdNhanVien = "";
        private string Pass = "";
        private void dgv_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            clsSoLine.Datum sl = (clsSoLine.Datum)dgv.SelectedItem;
            if (sl != null)
            {
                IdNhanVien = sl.emp_id;
                Soline = sl.extension_number;
                Pass = sl.password;
            }
        }

        private void dgv_PreviewMouseWheel(object sender, MouseWheelEventArgs e)
        {
            Main.scrollMain.ScrollToVerticalOffset(Main.scrollMain.VerticalOffset - e.Delta);
        }
    }
}
