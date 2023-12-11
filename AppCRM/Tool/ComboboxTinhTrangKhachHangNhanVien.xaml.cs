using AppCRM.Views.KhachHang.TinhTrangKhachHang;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace AppCRM.Tool
{
    /// <summary>
    /// Interaction logic for ComboboxTinhTrangKhachHangNhanVien.xaml
    /// </summary>
    public partial class ComboboxTinhTrangKhachHangNhanVien : UserControl,INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        private List<clsTinhTrangKhachHang.Datum> _listTinhTrang = new List<clsTinhTrangKhachHang.Datum>();
        public ComboboxTinhTrangKhachHangNhanVien()
        {
            InitializeComponent();
            this.DataContext = this;
            LoadDataTinhTrangKhachHang();
        }
        public List<clsTinhTrangKhachHang.Datum> ListTinhTrang { get => _listTinhTrang; set => _listTinhTrang = value; }

        private void LoadDataTinhTrangKhachHang()
        {
            try
            {
                cbx.Items.Clear();
                using (HttpClient httpClient = new HttpClient())
                {
                    //string url = Properties.Resources.URL + "listGroupCustomer";
                    string url = "https://crm.timviec365.vn/ApiWinform/listStatusCustomer";
                    httpClient.DefaultRequestHeaders.Add("Authorization", AppCRM.Properties.Settings.Default.TokenNhanVien);
                    var kq = httpClient.GetAsync(url);
                    clsTinhTrangKhachHang.Root api = JsonConvert.DeserializeObject<clsTinhTrangKhachHang.Root>(kq.Result.Content.ReadAsStringAsync().Result);
                    if (api != null)
                    {

                        foreach (var item in api.data)
                        {
                            if (item.status == 1)
                            {
                                clsBien.listIdTinhTrang.Add(item.stt_id);
                                cbx.Items.Add(item.stt_name);
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

        private void Border_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {

            if (cbx.IsDropDownOpen == false)
            {
                cbx.IsDropDownOpen = true;
            }
            else
            {
                cbx.IsDropDownOpen = false;
            }

        }
        private List<object> _test = new List<object>();

        public List<object> test
        {
            get { return _test; }
            set { _test = value; OnPropertyChanged(); }
        }

        private void cbx_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string[] Ten = cbx.SelectedItem.ToString().Split(Convert.ToChar(":"));
            string ten2 = Ten[Ten.Length - 1];
            test.Add(ten2);
            test = test.ToList();

            clsBien.listTinhTrang.Add(ten2);
        }

        private void btnXoaPB_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            string item = (sender as TextBlock).DataContext as string;
            test.Remove(item);
            test = test.ToList();
            clsBien.listTinhTrang.Remove(item);
        }
    }
}
