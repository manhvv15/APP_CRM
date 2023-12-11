using AppCRM.Model.APIEntity;
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
using System.Windows.Forms;
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
    /// Interaction logic for SelectionBox.xaml
    /// </summary>
    public partial class SelectionBox : System.Windows.Controls.UserControl, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        
        //private List<clsPhongBan> lst = new List<clsPhongBan>();
        private Model.APIEntity.DataLogin_Company _cpn;
        public DataLogin_Company cpn { get => _cpn; set => _cpn = value; }
        private List<Item> lstDataPB = new List<Item>();
        public SelectionBox()
        {
            InitializeComponent();
            this.DataContext = this;
            
            LoadDataPhongBan();
            //LoadDataNPhongBan2();
        }
        public void LoadDataPhongBan(/*Model.APIEntity.DataLogin_Company data*/)
        {
            try
            {
                //cbx.Items.Clear();
                using (WebClient webClient = new WebClient())
                {
                    //string url = Properties.Resources.URL + "listGroupCustomer";
                    string url = $"https://chamcong.24hpay.vn/service/list_department.php?id_com={clsBien.IdCongTy}";
                    webClient.Headers.Add("Authorization", AppCRM.Properties.Settings.Default.Token);
                    var kq = webClient.UploadValues(new Uri(url), webClient.QueryString);
                    Root api = JsonConvert.DeserializeObject<Root>(UnicodeEncoding.UTF8.GetString(kq));
                    if (api.data != null)
                    {
                        foreach (var item in api.data.items)
                        {
                            //lst.Add(item);
                            lstDataPB.Add(item);
                            cbx.Items.Add(item.dep_name);
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
        public void LoadDataNPhongBan2()
        {
            try
            {
                using (HttpClient httpClient = new HttpClient())
                {
                    //string url = Properties.Resources.URL + "listGroupCustomer";
                    string url = "https://crm.timviec365.vn/ApiWinform/listGroupCustomer";
                    httpClient.DefaultRequestHeaders.Add("Authorization", AppCRM.Properties.Settings.Default.Token);
                    var kq = httpClient.GetAsync(url);
                    Root api = JsonConvert.DeserializeObject<Root>(kq.Result.Content.ReadAsStringAsync().Result);
                    if (api != null)
                    {

                        foreach (var item in api.data.items)
                        {
                            
                            //dgv.ItemsSource = ListCustomer;
                            cbx.Items.Add(item.dep_name);

                            //cbo.Items.Add(item.gr_id);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                var check = ex.Message;
            }

        }
        private List<object> _test=new List<object>();

        public List<object> test
        {
            get { return _test; }
            set { _test = value; OnPropertyChanged(); }
        }
        

        private void Border_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
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

        private void cbx_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string[] Ten = cbx.SelectedItem.ToString().Split(Convert.ToChar(":"));
            string ten2 = Ten[Ten.Length - 1];
            test.Add(ten2);
            test = test.ToList();

            clsBien.listPhongBan.Add(ten2);
            LoadDanhSachIdPhongBan();
            //clsBien.ListPhongBan.ToList();
        }
        private void LoadDanhSachIdPhongBan()
        {
            clsBien.listIDPhongBan.Clear();
            foreach (Item it in lstDataPB)
            {
                foreach (string TenPhongBan in clsBien.listPhongBan)
                {
                    if (TenPhongBan == it.dep_name)
                    {
                        clsBien.listIDPhongBan.Add(it.dep_id);
                    }
                }
            }
        }
        private void Run_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            
        }

        private void btnXoaPB_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            string item = (sender as TextBlock).DataContext as string;
            test.Remove(item);
            test = test.ToList();
            clsBien.listPhongBan.Remove(item);
            LoadDanhSachIdPhongBan();
        }
    }
}
