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
    /// Interaction logic for frmTongDaiSauKetNoi.xaml
    /// </summary>
    public partial class frmTongDaiSauKetNoi : Page
    {
        private List<clsSoLine.Datum> lstSoLine = new List<clsSoLine.Datum>();

        public List<clsSoLine.Datum> LstSoLine { get => lstSoLine; set => lstSoLine = value; }
        private List<clsLichSuCuocGoi.Item> _lstLichSuCuocGoi = new List<clsLichSuCuocGoi.Item>();

        public List<clsLichSuCuocGoi.Item> LstLichSuCuocGoi { get => _lstLichSuCuocGoi; set => _lstLichSuCuocGoi = value; }
        
        private List<clsLichSuCuocGoi.Item> _lstLichSuCuocGoiDaTraLoiTrongTongDai = new List<clsLichSuCuocGoi.Item>();
        public List<clsLichSuCuocGoi.Item> LstLichSuCuocGoiDaTraLoiTrongTongDai { get => _lstLichSuCuocGoiDaTraLoiTrongTongDai; set => _lstLichSuCuocGoiDaTraLoiTrongTongDai = value; }
        private List<clsLichSuCuocGoi.Item> _lstCuocGoiKhongTraLoi = new List<clsLichSuCuocGoi.Item>();
        public List<clsLichSuCuocGoi.Item> LstCuocGoiKhongTraLoi { get => _lstCuocGoiKhongTraLoi; set => _lstCuocGoiKhongTraLoi = value; }
        private List<clsLichSuCuocGoi.Item> _lstCuocGoi = new List<clsLichSuCuocGoi.Item>();
        public List<clsLichSuCuocGoi.Item> LstCuocGoi { get => _lstCuocGoi; set => _lstCuocGoi = value; }
        private Model.APIEntity.DataLogin_Employee data;
        private string TokenAc = "";
        private string TongSoCuocGoiTrongNgay = "";
        private string TongSoCuocGoiNgheMay = "";
        private string TongSoCuocGoiKhongTraLoi = "";
        private string TongThoiGianGoi = "";
        private string TrungBinhCuocGoi = "";
        System.Windows.Threading.DispatcherTimer dispatcherTimer = new System.Windows.Threading.DispatcherTimer();
        private frmThanhMenuDoc Main;
        public frmTongDaiSauKetNoi(frmThanhMenuDoc main, List<clsSoLine.Datum> lst, Model.APIEntity.DataLogin_Employee dt, string TokenAcess)
        {
            InitializeComponent();
            LoadTongDai.Visibility = Visibility.Visible;
            Main = main;
            main.scrollMain.HorizontalScrollBarVisibility = ScrollBarVisibility.Disabled;
            TokenAc = TokenAcess;
            LstSoLine = lst;
            data = dt;
            btnPage1.Background = Brushes.BlueViolet;
            dispatcherTimer.Tick += new EventHandler(dispatcherTimer_Tick);
            dispatcherTimer.Interval = new TimeSpan(0, 0, 1);
            dispatcherTimer.Start();
            
        }

        private void dispatcherTimer_Tick(object sender, EventArgs e)
        {
            LoadLichSuCuocGoiTrongTongDai();
        }

        private void LoadLichSuCuocGoiTrongTongDai()
        {
            try
            {
                using (HttpClient httpClient = new HttpClient())
                {
                    //string url = Properties.Resources.URL + "listGroupCustomer";
                    string url = $"https://s02.oncall.vn:8900/api/call_logs/list";
                    //string url = $"https://c02.oncall.vn:8900/api/call_logs/list?start_time=2023-04-04 00:00:00 GMT+07:00&end_time=2023-04-04 23:59:59 GMT+07:00";
                    httpClient.DefaultRequestHeaders.Add("access_token", TokenAc);
                    var kq = httpClient.GetAsync(url);
                    clsLichSuCuocGoi.Root api = JsonConvert.DeserializeObject<clsLichSuCuocGoi.Root>(kq.Result.Content.ReadAsStringAsync().Result);
                    if (api.items != null)
                    {
                        int TongTg = 0;

                        TongSoCuocGoiTrongNgay = api.items.Count.ToString();
                        foreach (var item in api.items)
                        {
                            if(item.status== "ANSWERED")
                            {
                                item.status = "Đã trả lời";
                            }
                            else if(item.status!= "ANSWERED")
                            {
                                item.status = "Không trả lời";
                            }
                            LstCuocGoi.Add(item);
                            if (item.status == "ANSWERED" && int.Parse(item.talk_duration) > 12)
                            {
                                LstLichSuCuocGoiDaTraLoiTrongTongDai.Add(item);
                            }
                            else
                            {
                                LstCuocGoiKhongTraLoi.Add(item);
                            }
                            
                            if (int.Parse(item.talk_duration) > 12)
                            {
                                TongTg += int.Parse(item.talk_duration);
                            }
                            
                        }
                        if (LstCuocGoi.Count > 10)
                        {
                            for (int i = 0; i < 10; i++)
                            {
                                LstLichSuCuocGoi.Add(LstCuocGoi[i]);
                            }
                        }
                        else
                        {
                            for (int i = 0; i < LstCuocGoi.Count; i++)
                            {
                                LstLichSuCuocGoi.Add(LstCuocGoi[i]);
                            }
                        }
                        dgv.ItemsSource = LstLichSuCuocGoi;
                        TongThoiGianGoi = TongTg.ToString();
                        TongSoCuocGoiNgheMay = LstLichSuCuocGoiDaTraLoiTrongTongDai.Count.ToString();
                        TongSoCuocGoiKhongTraLoi = LstCuocGoiKhongTraLoi.Count.ToString();
                        double Tb = 0;
                        Tb = double.Parse(TongThoiGianGoi) / double.Parse(TongSoCuocGoiNgheMay);
                        Tb = Math.Round(Tb, 2);
                        TrungBinhCuocGoi = Tb.ToString();
                        textSoCuocGoi.Text = TongSoCuocGoiTrongNgay;
                        textTongThoiGianGoi.Text = TongThoiGianGoi;
                        textSoNgheMay.Text = TongSoCuocGoiNgheMay;
                        textSoKhongTraLoi.Text = TongSoCuocGoiKhongTraLoi;
                        textTrungBinh.Text = TrungBinhCuocGoi+"s/ cuộc gọi";
                        //textTongThoiGianGoi.Text = TongThoiGianGoi;
                    }
                    dispatcherTimer.Stop();
                    LoadTongDai.Visibility = Visibility.Collapsed;
                }
            }
            catch (Exception ex)
            {
                var check = ex.Message;
            }
        }
        private void loadDuLieuCuocGoi()
        {
            if(textPage1.Text != "1")
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
                    LstLichSuCuocGoi.Add(LstCuocGoi[i]);
                }
                dgv.ItemsSource = LstLichSuCuocGoi;
                
            }
            else
            {
                btnDau.Visibility = Visibility.Collapsed;
                btnLui1.Visibility = Visibility.Collapsed;
                btnPage1.Background = Brushes.BlueViolet;
                btnPage2.Background = Brushes.White;
                btnPage3.Background = Brushes.White;
                if (LstCuocGoi.Count > 10)
                {
                    for (int i = 0; i < 10; i++)
                    {
                        LstLichSuCuocGoi.Add(LstCuocGoi[i]);
                    }
                    dgv.ItemsSource = LstLichSuCuocGoi;
                }
                else
                {
                    for (int i = 0; i < LstCuocGoi.Count; i++)
                    {
                        LstLichSuCuocGoi.Add(LstCuocGoi[i]);
                    }
                    dgv.ItemsSource = LstLichSuCuocGoi;
                }
                
            }
        }

        private void btnBoLoc_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            Main.pnlShowPopup.Children.Add(new ViewsCongTy.ChamSocKhachHang.TongDai.PopUp.PopUpBoLoc());
        }

        private void btnGhiAm_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            frmGhiAm frm = new frmGhiAm(Main, TokenAc, data);
            pnlHienThi.Children.Clear();
            object content = frm.Content;
            frm.Content = null;
            //frm.Close();
            pnlChucNang.Visibility = Visibility.Collapsed;
            pnlHienThi.Children.Add(content as UIElement);
        }

        private void btnThongKe_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            frmThongKeTongDai frm = new frmThongKeTongDai(Main);
            pnlHienThi2.Children.Clear();
            object content = frm.Content;
            frm.Content = null;
            //frm.Close();
            //pnlChucNang.Visibility = Visibility.Collapsed;
            pnlHienThi2.Children.Add(content as UIElement);
        }

        private void btnQuanLyLine_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            frmQuanLyLine frm = new frmQuanLyLine(Main,LstSoLine,data);
            pnlHienThi2.Children.Clear();
            object content = frm.Content;
            frm.Content = null;
            //frm.Close();
            //pnlChucNang.Visibility = Visibility.Collapsed;
            pnlHienThi2.Children.Add(content as UIElement);
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
            LstLichSuCuocGoi = new List<clsLichSuCuocGoi.Item>();
            btnDau.Visibility = Visibility.Collapsed;
            btnLui1.Visibility = Visibility.Collapsed;
            btnPage1.Background = Brushes.BlueViolet;
            btnPage2.Background = Brushes.White;
            btnPage3.Background = Brushes.White;
            loadDuLieuCuocGoi();
            
        }

        private void btnPage1_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            LstLichSuCuocGoi = new List<clsLichSuCuocGoi.Item>();
            btnCuoi.Visibility = Visibility.Visible;
            btnLen1.Visibility = Visibility.Visible;
            loadDuLieuCuocGoi();
        }

        private void btnPage2_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            LstLichSuCuocGoi = new List<clsLichSuCuocGoi.Item>();
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
                    LstLichSuCuocGoi.Add(LstCuocGoi[i]);
                }
                dgv.ItemsSource = LstLichSuCuocGoi;
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
                if (LstCuocGoi.Count > 20)
                {
                    for (int i = 10; i < 20; i++)
                    {
                        LstLichSuCuocGoi.Add(LstCuocGoi[i]);
                    }

                    dgv.ItemsSource = LstLichSuCuocGoi;
                }
                else if (LstCuocGoi.Count > 10 && LstCuocGoi.Count < 20)
                {
                    for (int i = 10; i < LstCuocGoi.Count; i++)
                    {
                        LstLichSuCuocGoi.Add(LstCuocGoi[i]);
                    }

                    dgv.ItemsSource = LstLichSuCuocGoi;
                }
                else
                {
                    dgv.ItemsSource = null;
                }
            }
        }
        private int TongSoTrang;
        private void btnPage3_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            LstLichSuCuocGoi = new List<clsLichSuCuocGoi.Item>();
            btnDau.Visibility = Visibility.Visible;
            btnLui1.Visibility = Visibility.Visible;
            TongSoTrang = int.Parse(TongSoCuocGoiTrongNgay) / 10;
            if (int.Parse(TongSoCuocGoiTrongNgay) % 10 > 0)
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
                    for(int i = TongSoTrang * 10 - 10; i < (TongSoTrang * 10) - (TongSoTrang * 10 - int.Parse(TongSoCuocGoiTrongNgay)); i++)
                    {
                        LstLichSuCuocGoi.Add(LstCuocGoi[i]);
                    }
                    dgv.ItemsSource = LstLichSuCuocGoi;
                    
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
                        LstLichSuCuocGoi.Add(LstCuocGoi[i]);
                    }

                    dgv.ItemsSource = LstLichSuCuocGoi;
                    
                }

            }
            else
            {
                btnPage1.Background = Brushes.White;
                btnPage2.Background = Brushes.White;
                btnPage3.Background = Brushes.BlueViolet;
                if (LstCuocGoi.Count > 30)
                {
                    for (int i = 20; i < 30; i++)
                    {
                        LstLichSuCuocGoi.Add(LstCuocGoi[i]);
                    }
                    dgv.ItemsSource = LstLichSuCuocGoi;
                }
                else if (LstCuocGoi.Count > 20 && LstCuocGoi.Count < 30)
                {
                    for (int i = 20; i < LstCuocGoi.Count; i++)
                    {
                        LstLichSuCuocGoi.Add(LstCuocGoi[i]);
                    }
                    dgv.ItemsSource = LstLichSuCuocGoi;
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
            LstLichSuCuocGoi = new List<clsLichSuCuocGoi.Item>();
            if (LstCuocGoi.Count > 30)
            {
                
                TongSoTrang = int.Parse(TongSoCuocGoiTrongNgay) / 10;
                if (TongSoTrang % 10 != 0)
                {
                    TongSoTrang++;
                }
                textPage3.Text = TongSoTrang.ToString();
                textPage2.Text = (TongSoTrang - 1).ToString();
                textPage1.Text = (TongSoTrang - 2).ToString();
                for (int i = TongSoTrang * 10 - 10; i < (TongSoTrang * 10) - (TongSoTrang * 10 - int.Parse(TongSoCuocGoiTrongNgay)); i++)
                {
                    LstLichSuCuocGoi.Add(LstCuocGoi[i]);
                }
                dgv.ItemsSource = LstLichSuCuocGoi;
            }
            else
            {

            }
        }

        private void dgv_PreviewMouseWheel(object sender, MouseWheelEventArgs e)
        {
            Main.scrollMain.ScrollToVerticalOffset(Main.scrollMain.VerticalOffset - e.Delta);
        }
    }
}
