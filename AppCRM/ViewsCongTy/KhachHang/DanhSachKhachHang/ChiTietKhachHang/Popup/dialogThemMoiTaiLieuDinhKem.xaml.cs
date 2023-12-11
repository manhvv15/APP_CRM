using RestSharp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using DataFormats = System.Windows.Forms.DataFormats;
using MessageBox = System.Windows.Forms.MessageBox;

namespace AppCRM.Views.KhachHang.DanhSachKhachHang.ChiTietKhachHang.Popup
{
    /// <summary>
    /// Interaction logic for dialogThemMoiTaiLieuDinhKem.xaml
    /// </summary>
    public partial class dialogThemMoiTaiLieuDinhKem : System.Windows.Controls.UserControl, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        private string IdKhachHang = "";
        private frmTaiLieuDinhKem frmTLDK;
        public dialogThemMoiTaiLieuDinhKem(string IdKH, frmTaiLieuDinhKem frm)
        {
            InitializeComponent();
            test = new List<object>();
            this.DataContext = this;
            frmTLDK = frm;
            IdKhachHang = IdKH;
        }
        private List<object> _test = new List<object>();

        public List<object> test
        {
            get { return _test; }
            set { _test = value; OnPropertyChanged(); }
        }
        private void btnHuy_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            this.Visibility = Visibility.Collapsed;
        }

        private void btnClose_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            this.Visibility = Visibility.Collapsed;
        }
        private string DuongDan = "";
        private void btnChonTep_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            
            OpenFileDialog open = new OpenFileDialog();
            DialogResult dr = open.ShowDialog();
            if (dr == System.Windows.Forms.DialogResult.OK)
            {
                DanhSachDuongDan.Clear();
                NhieuFile.Visibility = Visibility.Collapsed;
                MotFile.Visibility = Visibility.Visible;
                test.Clear();
                DuongDan = open.FileName;
                string[] DSTenFile = DuongDan.Split(Convert.ToChar("\\"));
                string[] DinhDangFile = DSTenFile[DSTenFile.Length - 1].Split(Convert.ToChar("."));
                if(DinhDangFile[DinhDangFile.Length - 1] == "jpg" || DinhDangFile[DinhDangFile.Length - 1] == "png" || DinhDangFile[DinhDangFile.Length - 1] == "pdf"|| DinhDangFile[DinhDangFile.Length - 1] == "docx"|| DinhDangFile[DinhDangFile.Length - 1] == "xlsx")
                {
                    textTenTaiLieu.Text = DSTenFile[DSTenFile.Length - 1];
                    if (DinhDangFile[DinhDangFile.Length - 1] == "jpg" || DinhDangFile[DinhDangFile.Length - 1] == "png" || DinhDangFile[DinhDangFile.Length - 1] == "pdf")
                    {
                        iconImgVsPDF.Visibility = Visibility.Visible;
                        iconExcel.Visibility = Visibility.Collapsed;
                        iconWord.Visibility = Visibility.Collapsed;
                    }
                    else if (DinhDangFile[DinhDangFile.Length - 1] == "docx")
                    {
                        iconImgVsPDF.Visibility = Visibility.Collapsed;
                        iconExcel.Visibility = Visibility.Collapsed;
                        iconWord.Visibility = Visibility.Visible;
                    }
                    else if (DinhDangFile[DinhDangFile.Length - 1] == "xlsx")
                    {
                        iconImgVsPDF.Visibility = Visibility.Collapsed;
                        iconExcel.Visibility = Visibility.Visible;
                        iconWord.Visibility = Visibility.Collapsed;
                    }
                    btnXoaFile.Visibility = Visibility.Visible;
                }
                
            }
        }

        private void btnXoaFile_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            iconImgVsPDF.Visibility = Visibility.Collapsed;
            iconExcel.Visibility = Visibility.Collapsed;
            iconWord.Visibility = Visibility.Collapsed;
            textTenTaiLieu.Text = "";
            btnXoaFile.Visibility = Visibility.Collapsed;
        }

        private void btnLuu_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (DanhSachDuongDan.Count > 0)
            {
                foreach(string duongdan in DanhSachDuongDan)
                {
                    using (RestClient restclient = new RestClient(new Uri("https://crm.timviec365.vn/ApiWinform/addFileCus")))
                    {
                        try
                        {
                            RestRequest request = new RestRequest();
                            request.Method = Method.Post;
                            request.AlwaysMultipartFormData = true;
                            request.AddHeader("Authorization", AppCRM.Properties.Settings.Default.Token);
                            request.AddParameter("customerId", IdKhachHang);
                            request.AddFile("files[]", duongdan);
                            RestResponse resAlbum = restclient.Execute(request);
                            var b = resAlbum.Content;
                            frmTLDK.LoadDLTaiLieuDinhKem();
                            this.Visibility = Visibility.Collapsed;
                        }
                        catch
                        {
                        }
                    }
                }
            }
            else
            {
                using (RestClient restclient = new RestClient(new Uri("https://crm.timviec365.vn/ApiWinform/addFileCus")))
                {
                    try
                    {
                        RestRequest request = new RestRequest();
                        request.Method = Method.Post;
                        request.AlwaysMultipartFormData = true;
                        request.AddHeader("Authorization", AppCRM.Properties.Settings.Default.Token);
                        request.AddParameter("customerId", IdKhachHang);
                        request.AddFile("files[]", DuongDan);
                        RestResponse resAlbum = restclient.Execute(request);
                        var b = resAlbum.Content;
                        frmTLDK.LoadDLTaiLieuDinhKem();
                        this.Visibility = Visibility.Collapsed;
                    }
                    catch
                    {
                    }
                }
            }
            
        }
        private List<string> DanhSachDuongDan = new List<string>();
        private void border_Drop(object sender, System.Windows.DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                NhieuFile.Visibility = Visibility.Visible;
                MotFile.Visibility = Visibility.Collapsed;
                // Note that you can have more than one file.
                string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
                foreach(string file in files)
                {
                    DanhSachDuongDan.Add(file);
                    string[] ff = file.Split(Convert.ToChar("\\"));
                    test.Add(ff[ff.Length - 1]);
                }
                test = test.ToList();
                // Assuming you have one file that you care about, pass it off to whatever
                // handling code you have defined.
            }
        }

        private void btnXoaFileDS_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            string item = (sender as TextBlock).DataContext as string;
            test.Remove(item);
            test = test.ToList();
        }

        private void Rectangle_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.Visibility = Visibility.Collapsed;
        }
    }
}
