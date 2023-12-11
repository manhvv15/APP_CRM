using AppCRM.Login.Entities;
using AppCRM.Views.ChamSocKhachHang.TongDai;
using Newtonsoft.Json;
using QRCoder;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Device.Location;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Security.Authentication;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
//using System.Windows.Shapes;

namespace AppCRM.Login.Views.Login
{
    /// <summary>
    /// Interaction logic for LoginCom.xaml
    /// </summary>
    public partial class LoginCom : Page, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        public LoginCom(LoginWindow login)
        {
            InitializeComponent();
            this.DataContext = this;
            WinLogin = login;
            WinLogin.Title = "Đăng nhập công ty";
            txtEmail.Text = AppCRM.Properties.Settings.Default.ComEmail;
            txtPass.Password = AppCRM.Properties.Settings.Default.ComPass;
            BrushConverter bc = new BrushConverter();
            textQuetMaQR.Foreground = (System.Windows.Media.Brush)bc.ConvertFrom("#4C5BD4");
            LineQuetMaQR.Stroke = (System.Windows.Media.Brush)bc.ConvertFrom("#4C5BD4");
            textDNTaiKhoan.Foreground = (System.Windows.Media.Brush)bc.ConvertFrom("#474747");
            LineDangNhapTK.Stroke = (System.Windows.Media.Brush)bc.ConvertFrom("#474747");
            pnlQuetMaQR.Visibility = Visibility.Visible;
            pnlDangNhapTKMK.Visibility = Visibility.Collapsed;
            GetLocationEvent();
            connectionSocket();
            /*if (!string.IsNullOrEmpty(AppCRM.Properties.Settings.Default.ComEmail) || !string.IsNullOrEmpty(AppCRM.Properties.Settings.Default.ComPass))
            {
                ckSave.IsChecked = true;
                txtEmail.Text = AppCRM.Properties.Settings.Default.ComEmail;
                txtPass.Password = AppCRM.Properties.Settings.Default.ComPass;
                txtPass.GetType().GetMethod("Select", BindingFlags.Instance | BindingFlags.NonPublic).Invoke(txtPass, new object[] { Pass.Length, 0 });
                txtPass.Focus();
            }
            else txtEmail.Focus();*/
        }
        //
        public LoginWindow WinLogin { get; set; }
        private string _Pass = "";
        public string Pass
        {
            get { return _Pass; }
            set { _Pass = value; OnPropertyChanged(); }
        }
        Regex regex = new Regex(@"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$", RegexOptions.CultureInvariant | RegexOptions.Singleline);
        Regex regexSDT = new Regex(@"0(1\d{9}|9\d{8})", RegexOptions.CultureInvariant | RegexOptions.Singleline);
        //
        private void SignIn(object sender, MouseButtonEventArgs e)
        {
            System.Diagnostics.Process.Start("https://quanlychung.timviec365.vn/dang-ky-cong-ty.html");
        }
        private void GoBack(object sender, MouseButtonEventArgs e)
        {
            WinLogin.Close();

            WinLogin.WinMain.IsFull = WinLogin.IsFull;
            WinLogin.WinMain.Width = WinLogin.ActualWidth;
            WinLogin.WinMain.Height = WinLogin.ActualHeight;
            WinLogin.WinMain.Left = WinLogin.Left;
            WinLogin.WinMain.Top = WinLogin.Top;

            WinLogin.WinMain.Show();
        }
        //Nhập PassWord
        private void txtPass_PasswordChanged(object sender, RoutedEventArgs e)
        {
            Pass = txtPass.Password;
            tblValidatePass.Text = "";
            if (string.IsNullOrEmpty(Pass))
            {
                tblValidatePass.Text = "Không được để trống";
            }

        }
        private int _TypeLogin = 1;

        public int TypeLogin
        {
            get { return _TypeLogin; }
            set { _TypeLogin = value; OnPropertyChanged(); }
        }
        private async void runLogin()
        {
            bool allow = true;
            tblValidateEmail.Text = tblValidatePass.Text = "";
            if (string.IsNullOrEmpty(txtEmail.Text))
            {
                allow = false;
                tblValidateEmail.Text = "Không được để trống";
            }
            else if (!regex.IsMatch(txtEmail.Text) && !regexSDT.IsMatch(txtEmail.Text))
            {
                allow = false;
                tblValidateEmail.Text = "Nhập không đúng định dạng";
            }
            if (string.IsNullOrEmpty(Pass))
            {
                allow = false;
                tblValidatePass.Text = "Không được để trống";
            }
            if (allow)
            {

                //frmThanhMenuDoc frm = new frmThanhMenuDoc();
                //frm.Show();
                if (pnlDangNhapTKMK.Visibility == Visibility.Visible)
                {
                    if (ckSave.IsChecked == true)
                    {
                        AppCRM.Properties.Settings.Default.ComEmail = txtEmail.Text;
                        AppCRM.Properties.Settings.Default.ComPass = Pass;
                        AppCRM.Properties.Settings.Default.Save();
                    }
                }
                try
                {
                    Dictionary<string, string> form = new Dictionary<string, string>();
                    Dictionary<string, string> form22 = new Dictionary<string, string>();
                    form.Add("email", txtEmail.Text);
                    form.Add("pass", Pass);
                    if (pnlQuetMaQR.Visibility == Visibility.Visible)
                    {
                        if (TypeLogin == 1)
                        {
                            form.Add("passtype", "1");
                        }
                    }
                    form22.Add("email", "nguyencongtien01it@gmail.com");
                    form22.Add("pass", "congtien01");
                    HttpClient httpClient = new HttpClient();
                    HttpClient httpClient22 = new HttpClient();
                    System.Net.ServicePointManager.SecurityProtocol = System.Net.SecurityProtocolType.Tls12;
                    var respon = await httpClient.PostAsync("https://tinhluong.timviec365.vn/api_app/company/login_comp.php", new FormUrlEncodedContent(form));
                    var responEmp = await httpClient22.PostAsync("https://tinhluong.timviec365.vn/api_app/employe/login_emp.php", new FormUrlEncodedContent(form22));
                    AppCRM.Model.APIEntity.API_Login_Company api = JsonConvert.DeserializeObject<AppCRM.Model.APIEntity.API_Login_Company>(respon.Content.ReadAsStringAsync().Result);
                    AppCRM.Model.APIEntity.API_Login_Employee apiEmp = JsonConvert.DeserializeObject<AppCRM.Model.APIEntity.API_Login_Employee>(responEmp.Content.ReadAsStringAsync().Result);
                    if (api.data != null)
                    {

                        if (ckSave.IsChecked == true)
                        {
                            AppCRM.Properties.Settings.Default.Token = api.data.token;
                            //AppCRM.Properties.Settings.Default.TokenNhanVien = apiEmp.data.token;
                            //AppCRM.Properties.Settings.Default.ComPass = Pass;
                            AppCRM.Properties.Settings.Default.Save();
                        }
                        api.data.pass = api.data.ToMD5(Pass);
                        //var main = new AppCRM.MainWindow();
                        Dictionary<string, string> formTD = new Dictionary<string, string>();

                        formTD.Add("switchboard", "fpt");
                        formTD.Add("account", "HNCX00693");
                        formTD.Add("password", "v2ohO6B1Nf4F");
                        formTD.Add("domain", "hncx00693.oncall");
                        HttpClient httpClientTD = new HttpClient();
                        httpClientTD.DefaultRequestHeaders.Add("Authorization", api.data.token);
                        System.Net.ServicePointManager.SecurityProtocol = System.Net.SecurityProtocolType.Tls12;
                        var responTD = await httpClientTD.PostAsync("https://crm.timviec365.vn/ApiWinform/settingSwitchboard", new FormUrlEncodedContent(formTD));
                        clsCapNhatKetNoiTongDai.Root apiTD = JsonConvert.DeserializeObject<clsCapNhatKetNoiTongDai.Root>(responTD.Content.ReadAsStringAsync().Result);
                        var main = new frmTrangChuSauDangNhapCongTy(api.data, apiEmp.data, WinLogin);

                        //main.IsFull = WinLogin.IsFull;
                        main.Width = WinLogin.Width;
                        main.Height = WinLogin.Height;
                        main.Left = WinLogin.Left;
                        main.Top = WinLogin.Top;

                        //main.LogOut = () =>
                        //{
                        //    main.Close();
                        //    WinLogin.LogOut(main.IsFull, main);
                        //};

                        WinLogin.Close();
                        main.ShowDialog();
                    }
                    else
                    {
                        var n = new Notify();
                        n.Type = Notify.NotifyType.Error;
                        n.setMessage("Đăng nhập không thành công");
                        WinLogin.ShowPopup(n);
                    }
                }
                catch (Exception ex)
                {
                    var n = new Notify();
                    n.Type = Notify.NotifyType.Error;
                    n.setMessage(ex.Message);
                    WinLogin.ShowPopup(n);
                }
            }
        }
        private void Login(object sender, MouseButtonEventArgs e)
        {
            runLogin();
        }
        private void txtPass_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key==Key.Enter)
            {
                runLogin();
            }
        }
        private void txtEmail_LostFocus(object sender, RoutedEventArgs e)
        {
            tblValidateEmail.Text ="";
            if (string.IsNullOrEmpty(txtEmail.Text))
            {
                tblValidateEmail.Text = "Không được để trống";
            }
            else if (!regex.IsMatch(txtEmail.Text) && !regexSDT.IsMatch(txtEmail.Text))
            {
                tblValidateEmail.Text = "Nhập không đúng định dạng";
            }
        }
        private void txtPass_LostFocus(object sender, RoutedEventArgs e)
        {
            tblValidatePass.Text = "";
            if (string.IsNullOrEmpty(Pass))
            {
                tblValidatePass.Text = "Không được để trống";
            }
        }
        private void txtEmail_TextChanged(object sender, TextChangedEventArgs e)
        {
            tblValidateEmail.Text = "";
            if (string.IsNullOrEmpty(txtEmail.Text))
            {
                tblValidateEmail.Text = "Không được để trống";
            }
            else if (!regex.IsMatch(txtEmail.Text) && !regexSDT.IsMatch(txtEmail.Text))
            {
                tblValidateEmail.Text = "Nhập không đúng định dạng";
            }
        }
        private void ckSave_Unchecked(object sender, RoutedEventArgs e)
        {
            AppCRM.Properties.Settings.Default.ComEmail = "";
            AppCRM.Properties.Settings.Default.ComPass = "";
            AppCRM.Properties.Settings.Default.Save();
        }
        private void ForgotPass(object sender, MouseButtonEventArgs e)
        {
            var z = new ForgotPasswordWindow(WinLogin);
            z.Type = 2;

            z.IsFull = WinLogin.IsFull;
            z.Width = WinLogin.ActualWidth;
            z.Height = WinLogin.ActualHeight;
            z.Left = WinLogin.Left;
            z.Top = WinLogin.Top;

            WinLogin.Hide();
            z.Show();
        }

        private void btnQuetMaQR_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            BrushConverter bc = new BrushConverter();
            textQuetMaQR.Foreground = (System.Windows.Media.Brush)bc.ConvertFrom("#4C5BD4");
            LineQuetMaQR.Stroke = (System.Windows.Media.Brush)bc.ConvertFrom("#4C5BD4");
            textDNTaiKhoan.Foreground = (System.Windows.Media.Brush)bc.ConvertFrom("#474747");
            LineDangNhapTK.Stroke = (System.Windows.Media.Brush)bc.ConvertFrom("#474747");
            pnlQuetMaQR.Visibility = Visibility.Visible;
            pnlDangNhapTKMK.Visibility = Visibility.Collapsed;
        }

        private void btnDangNhapTKMK_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            BrushConverter bc = new BrushConverter();
            textQuetMaQR.Foreground = (System.Windows.Media.Brush)bc.ConvertFrom("#474747");
            LineQuetMaQR.Stroke = (System.Windows.Media.Brush)bc.ConvertFrom("#474747");
            textDNTaiKhoan.Foreground = (System.Windows.Media.Brush)bc.ConvertFrom("#4C5BD4");
            LineDangNhapTK.Stroke = (System.Windows.Media.Brush)bc.ConvertFrom("#4C5BD4");
            pnlQuetMaQR.Visibility = Visibility.Collapsed;
            pnlDangNhapTKMK.Visibility = Visibility.Visible;
        }
        //Hàm random để gen id qr code
        private static Random random = new Random();
        public static string RandomString(int length)
        {
            const string chars = "AaBbCcDdEeFfGgHhIiJjKkLlMmNnOoPpQqRrSsTtUuVvWwXxYyZz0123456789";
            return new string(Enumerable.Repeat(chars, length)
                .Select(s => s[random.Next(s.Length)]).ToArray());
        }
        private string IdQR;
        private void CreateQRCode(double? lat, double? lng)
        {
            try
            {
                string logo = Environment.GetEnvironmentVariable("APPDATA") + @"\Chat365\chat365_logo.png";
                IdQR = RandomString(8);
                string x = Base64Encode(IdQR);
                string IdDevice = $"{RandomString(8)}-{RandomString(4)}-{RandomString(4)}-{RandomString(4)}-{RandomString(12)}";
                string info = JsonConvert.SerializeObject(new infoQR("QRLoginPc", (x + "++"), IdDevice, $"{Environment.MachineName}-Windows", lat, lng, DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss")));
                QRCodeGenerator qRCodeGenerator = new QRCodeGenerator();
                QRCodeData qRCodeData = qRCodeGenerator.CreateQrCode(info, QRCodeGenerator.ECCLevel.Q);
                QRCode qRCode = new QRCode(qRCodeData);
                Bitmap qRCodeImage = qRCode.GetGraphic(20);

                this.Dispatcher.Invoke(() =>
                {
                    qrcode_login.ImageSource = BitmapToImageSource(qRCodeImage);
                });
            }
            catch (Exception ex)
            {
            }
        }
        // Đối tượng QR info
        public class infoQR
        {
            public infoQR(string qRType, string idQR, string idComputer, string nameComputer, double? latitude, double? longitude, string time)
            {
                QRType = qRType;
                this.idQR = idQR;
                IdComputer = idComputer;
                NameComputer = nameComputer;
                this.latitude = latitude;
                this.longitude = longitude;
                Time = time;
            }

            public string QRType { get; set; }
            public string idQR { get; set; }
            public string IdComputer { get; set; }
            public string NameComputer { get; set; }
            public double? latitude { get; set; }
            public double? longitude { get; set; }
            public string Time { get; set; }

        }
        // Hàm chuyển bitmap thành ảnh
        private ImageSource BitmapToImageSource(Bitmap bitmap)
        {
            using (MemoryStream memory = new MemoryStream())
            {
                bitmap.Save(memory, System.Drawing.Imaging.ImageFormat.Bmp);
                memory.Position = 0;
                BitmapImage bitmapImage = new BitmapImage();
                bitmapImage.BeginInit();
                bitmapImage.StreamSource = memory;
                bitmapImage.CacheOption = BitmapCacheOption.OnLoad;
                bitmapImage.EndInit();
                return bitmapImage;
            }
        }
        // Hàm mã hóa base64
        public static string Base64Encode(string plainText)
        {
            var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(plainText);
            return System.Convert.ToBase64String(plainTextBytes);
        }

        // Hàm giải mã base64
        public static string Base64Decode(string base64EncodedData)
        {
            var base64EncodedBytes = System.Convert.FromBase64String(base64EncodedData);
            return System.Text.Encoding.UTF8.GetString(base64EncodedBytes);
        }
        GeoCoordinateWatcher watcher;
        private double latitude;
        private double longitude;
        private void connectionSocket()
        {
            try
            {
                ConnectSocket Socket = new ConnectSocket();
                Socket.WIO.On("QRLogin", response =>
                {
                    try
                    {
                        string QrId = response.GetValue<string>(0);
                        string Email = response.GetValue<string>(1).Replace("+", "");
                        Email = Base64Decode(Email);
                        string Password = response.GetValue<string>(2).Replace("+", "");
                        Password = Base64Decode(Password);

                        if (QrId == IdQR)
                        {
                            this.Dispatcher.Invoke(() =>
                            {
                                Pass = Password;
                                txtEmail.Text = Email;
                                //Properties.Settings.Default.ComEmail = Email;
                                //Properties.Settings.Default.ComPass = Password;
                                //Properties.Settings.Default.Save();
                                runLogin();
                            });
                        }
                    }
                    catch (Exception ex)
                    {

                    }
                });
            }
            catch (Exception ex)
            {

            }
        }
        public void GetLocationEvent()
        {
            Task t = new Task(() =>
            {
                CreateQRCode(0, 0);
                //this.watcher = new GeoCoordinateWatcher();
                //if (this.watcher.Status == GeoPositionStatus.NoData || this.watcher.Status == GeoPositionStatus.Ready)
                //{
                //    if (watcher.TryStart(false, TimeSpan.FromMilliseconds(20000)))
                //    {
                //        bool ck = true;
                //        while (ck)
                //        {
                //            latitude = this.watcher.Position.Location.Latitude;
                //            longitude = this.watcher.Position.Location.Longitude;
                //            if (latitude != double.NaN && longitude != double.NaN && latitude > 0 && longitude > 0)
                //            {
                //                CreateQRCode(latitude, longitude);
                //                ck = false;
                //            }
                //        }

                //    }

                //}
                //else
                //{
                //    latitude = 0;
                //    longitude = 0;
                //}
            });
            t.Start();
        }
    }
}
