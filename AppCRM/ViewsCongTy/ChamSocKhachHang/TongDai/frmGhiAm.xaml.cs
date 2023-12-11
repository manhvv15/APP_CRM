using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Media;
using System.Net;
using System.Net.Http;
using System.Reflection;
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

namespace AppCRM.Views.ChamSocKhachHang.TongDai
{
    /// <summary>
    /// Interaction logic for frmGhiAm.xaml
    /// </summary>
    public partial class frmGhiAm : Page, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        private string TokenAccess = "";
        private List<clsGhiAm.Item> _lstGhiAm = new List<clsGhiAm.Item>();
        public List<clsGhiAm.Item> LstGhiAm { get => _lstGhiAm; set => _lstGhiAm = value; }
        private List<clsGhiAm.Item> _lstGhiAmPhanTrang = new List<clsGhiAm.Item>();
        public List<clsGhiAm.Item> LstGhiAmPhanTrang { get => _lstGhiAmPhanTrang; set => _lstGhiAmPhanTrang = value; }
        private string TongSoGhiAm = "";
        private int TongSoTrang;
        private frmThanhMenuDoc Main;
        public frmGhiAm(frmThanhMenuDoc main, string TokenAc,Model.APIEntity.DataLogin_Employee dt)
        {
            InitializeComponent();
            Main = main;
            TokenAccess = TokenAc;
            btnPage1.Background = Brushes.BlueViolet;
            LoadDataFileGhiAm();
            
        }

        
        private void LoadDuLieuGhiAm()
        {
            if (textPage1.Text != "1")
            {
                textPage1.Text = (int.Parse(textPage1.Text) - 1).ToString();
                textPage2.Text = (int.Parse(textPage2.Text) - 1).ToString();
                textPage3.Text = (int.Parse(textPage3.Text) - 1).ToString();
                btnPage1.Background = Brushes.White;
                btnPage2.Background = Brushes.BlueViolet;
                btnPage3.Background = Brushes.White;
                btnDau.Visibility = Visibility.Visible;
                btnLui1.Visibility = Visibility.Visible;
                for (int i = (int.Parse(textPage2.Text) * 10) - 10; i < int.Parse(textPage2.Text) * 10; i++)
                {
                    LstGhiAmPhanTrang.Add(LstGhiAm[i]);
                }
                dgv.ItemsSource = LstGhiAmPhanTrang;

            }
            else
            {
                btnDau.Visibility = Visibility.Collapsed;
                btnLui1.Visibility = Visibility.Collapsed;
                btnPage1.Background = Brushes.BlueViolet;
                btnPage2.Background = Brushes.White;
                btnPage3.Background = Brushes.White;
                if (LstGhiAm.Count > 10)
                {
                    for (int i = 0; i < 10; i++)
                    {
                        LstGhiAmPhanTrang.Add(LstGhiAm[i]);
                    }
                    dgv.ItemsSource = LstGhiAmPhanTrang;
                }
                else
                {
                    for (int i = 0; i < LstGhiAm.Count; i++)
                    {
                        LstGhiAmPhanTrang.Add(LstGhiAm[i]);
                    }
                    dgv.ItemsSource = LstGhiAmPhanTrang;
                }

            }
        }
        private void LoadDataFileGhiAm()
        {
            try
            {
                using (HttpClient httpClient = new HttpClient())
                {
                    string url = $"https://s02.oncall.vn:8900/api/recordfiles/extension/list";
                    httpClient.DefaultRequestHeaders.Add("access_token", TokenAccess);
                    var kq = httpClient.GetAsync(url);
                    clsGhiAm.Root api = JsonConvert.DeserializeObject<clsGhiAm.Root>(kq.Result.Content.ReadAsStringAsync().Result);
                    if (api.items != null)
                    {
                        
                        foreach (var item in api.items)
                        {
                            LstGhiAm.Add(item);

                        }
                        TongSoGhiAm = LstGhiAm.Count.ToString();
                        for(int i = 0; i < 10; i++)
                        {
                            LstGhiAmPhanTrang.Add(LstGhiAm[i]);
                        }
                        dgv.ItemsSource = LstGhiAmPhanTrang;
                    }

                }
            }
            catch (Exception ex)
            {
                var check = ex.Message;
            }
        }
        private string DuongDanFileGhiAm = "";
        private string TenFileGhiAm = "";
        private void dgv_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            clsGhiAm.Item gA = (clsGhiAm.Item)dgv.SelectedItem;
            if (gA != null)
            {
                TenFileGhiAm = gA.filename;
                DuongDanFileGhiAm = gA.filepath;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //var basePath = System.AppDomain.CurrentDomain.BaseDirectory;
            
        }
        private string _path;
        public string path
        {
            get { return _path; }
            set
            {
                _path = value; OnPropertyChanged();
            }
        }
        private void tb_PlayGhiAm_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            //path = $"https://c02.oncall.vn:8883/filedown/{DuongDanFileGhiAm}?filename={TenFileGhiAm}";
            //MediaPlayer mda = new MediaPlayer();
            System.Diagnostics.Process.Start($"https://c02.oncall.vn:8883/filedown/{DuongDanFileGhiAm}?filename={TenFileGhiAm}");
            //var uri = new Uri($"C:\\Users\\Administrator\\Downloads\\{TenFileGhiAm}");
            //mda.Open(uri);
            //mda.Play();
        }
        
        private void btnDau_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            btnDau.Visibility = Visibility.Collapsed;
            btnLui1.Visibility = Visibility.Collapsed;
            btnCuoi.Visibility = Visibility.Visible;
            btnLen1.Visibility = Visibility.Visible;
            textPage1.Text = "1";
            textPage2.Text = "2";
            textPage3.Text = "3";
            btnPage1.Background = Brushes.BlueViolet;
            btnPage2.Background = Brushes.White;
            btnPage3.Background = Brushes.White;
            LstGhiAmPhanTrang = new List<clsGhiAm.Item>();
            btnDau.Visibility = Visibility.Collapsed;
            btnLui1.Visibility = Visibility.Collapsed;
            btnPage1.Background = Brushes.BlueViolet;
            btnPage2.Background = Brushes.White;
            btnPage3.Background = Brushes.White;
            LoadDuLieuGhiAm();
        }

        private void btnPage1_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            LstGhiAmPhanTrang = new List<clsGhiAm.Item>();
            btnCuoi.Visibility = Visibility.Visible;
            btnLen1.Visibility = Visibility.Visible;
            LoadDuLieuGhiAm();
        }

        private void btnPage2_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            LstGhiAmPhanTrang = new List<clsGhiAm.Item>();
            btnDau.Visibility = Visibility.Visible;
            btnLui1.Visibility = Visibility.Visible;
            btnCuoi.Visibility = Visibility.Visible;
            btnLen1.Visibility = Visibility.Visible;
            if (textPage2.Text != "2")
            {
                btnPage1.Background = Brushes.White;
                btnPage2.Background = Brushes.BlueViolet;
                btnPage3.Background = Brushes.White;
                for (int i = (int.Parse(textPage2.Text) * 10) - 10; i < int.Parse(textPage2.Text) * 10; i++)
                {
                    LstGhiAmPhanTrang.Add(LstGhiAm[i]);
                }
                dgv.ItemsSource = LstGhiAmPhanTrang;
            }
            else
            {
                btnPage1.Background = Brushes.White;
                btnPage2.Background = Brushes.BlueViolet;
                btnPage3.Background = Brushes.White;
                btnLui1.Visibility = Visibility.Visible;
                btnDau.Visibility = Visibility.Visible;
                btnLen1.Visibility = Visibility.Visible;
                btnCuoi.Visibility = Visibility.Visible;
                if (LstGhiAm.Count > 20)
                {
                    for (int i = 10; i < 20; i++)
                    {
                        LstGhiAmPhanTrang.Add(LstGhiAm[i]);
                    }

                    dgv.ItemsSource = LstGhiAmPhanTrang;
                }
                else if (LstGhiAm.Count > 10 && LstGhiAm.Count < 20)
                {
                    for (int i = 10; i < LstGhiAm.Count; i++)
                    {
                        LstGhiAmPhanTrang.Add(LstGhiAm[i]);
                    }

                    dgv.ItemsSource = LstGhiAmPhanTrang;
                }
                else
                {
                    dgv.ItemsSource = null;
                }
            }
        }

        private void btnPage3_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            LstGhiAmPhanTrang = new List<clsGhiAm.Item>();
            btnDau.Visibility = Visibility.Visible;
            btnLui1.Visibility = Visibility.Visible;
            TongSoTrang = int.Parse(TongSoGhiAm) / 10;
            if (int.Parse(TongSoGhiAm) % 10 > 0)
            {
                TongSoTrang++;
            }
            if (TongSoTrang > 3)
            {
                if (textPage3.Text == TongSoTrang.ToString())
                {
                    btnCuoi.Visibility = Visibility.Collapsed;
                    btnLen1.Visibility = Visibility.Collapsed;
                    btnPage1.Background = Brushes.White;
                    btnPage2.Background = Brushes.White;
                    btnPage3.Background = Brushes.BlueViolet;
                    for (int i = TongSoTrang * 10 - 10; i < (TongSoTrang * 10) - (TongSoTrang * 10 - int.Parse(TongSoGhiAm)); i++)
                    {
                        LstGhiAmPhanTrang.Add(LstGhiAm[i]);
                    }
                    dgv.ItemsSource = LstGhiAmPhanTrang;

                }
                else
                {
                    textPage1.Text = (int.Parse(textPage1.Text) + 1).ToString();
                    textPage2.Text = (int.Parse(textPage2.Text) + 1).ToString();
                    textPage3.Text = (int.Parse(textPage3.Text) + 1).ToString();
                    btnPage1.Background = Brushes.White;
                    btnPage2.Background = Brushes.BlueViolet;
                    btnPage3.Background = Brushes.White;
                    btnCuoi.Visibility = Visibility.Visible;
                    btnLen1.Visibility = Visibility.Visible;
                    for (int i = (int.Parse(textPage2.Text) * 10) - 10; i < int.Parse(textPage2.Text) * 10; i++)
                    {
                        LstGhiAmPhanTrang.Add(LstGhiAm[i]);
                    }

                    dgv.ItemsSource = LstGhiAmPhanTrang;

                }

            }
            else
            {
                btnPage1.Background = Brushes.White;
                btnPage2.Background = Brushes.White;
                btnPage3.Background = Brushes.BlueViolet;
                if (LstGhiAm.Count > 30)
                {
                    for (int i = 20; i < 30; i++)
                    {
                        LstGhiAmPhanTrang.Add(LstGhiAm[i]);
                    }
                    dgv.ItemsSource = LstGhiAmPhanTrang;
                }
                else if (LstGhiAm.Count > 20 && LstGhiAm.Count < 30)
                {
                    for (int i = 20; i < LstGhiAm.Count; i++)
                    {
                        LstGhiAmPhanTrang.Add(LstGhiAm[i]);
                    }
                    dgv.ItemsSource = LstGhiAmPhanTrang;
                }
                else
                {
                    dgv.ItemsSource = null;
                }
            }
        }

        private void btnCuoi_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            btnDau.Visibility = Visibility.Visible;
            btnLui1.Visibility = Visibility.Visible;
            btnCuoi.Visibility = Visibility.Collapsed;
            btnLen1.Visibility = Visibility.Collapsed;
            btnPage1.Background = Brushes.White;
            btnPage2.Background = Brushes.White;
            btnPage3.Background = Brushes.BlueViolet;
            LstGhiAmPhanTrang = new List<clsGhiAm.Item>();
            TongSoTrang = int.Parse(TongSoGhiAm) / 10;
            if (TongSoTrang % 10 != 0)
            {
                TongSoTrang++;
            }
            textPage3.Text = TongSoTrang.ToString();
            textPage2.Text = (TongSoTrang - 1).ToString();
            textPage1.Text = (TongSoTrang - 2).ToString();
            for (int i = TongSoTrang * 10 - 10; i < (TongSoTrang * 10) - (TongSoTrang * 10 - int.Parse(TongSoGhiAm)); i++)
            {
                LstGhiAmPhanTrang.Add(LstGhiAm[i]);
            }
            dgv.ItemsSource = LstGhiAmPhanTrang;
        }

        private void dgv_PreviewMouseWheel(object sender, MouseWheelEventArgs e)
        {
            Main.scrollMain.ScrollToVerticalOffset(Main.scrollMain.VerticalOffset - e.Delta);
        }
    }
}
