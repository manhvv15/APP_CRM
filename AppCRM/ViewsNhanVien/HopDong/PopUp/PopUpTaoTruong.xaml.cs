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
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace AppCRM.Views.HopDong.Popup
{
    /// <summary>
    /// Interaction logic for PopUpTaoTruongNhanVien.xaml
    /// </summary>
    public partial class PopUpTaoTruongNhanVien : UserControl, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        private ThemMoiHopDongNhanVien frmThemMoi;
        private string IdTruongThayDoi = "";
        public PopUpTaoTruongNhanVien(ThemMoiHopDongNhanVien frm, string TieuDe, string TenTruong, string IdTruong)
        {
            InitializeComponent();
            this.DataContext = this;
            textTieuDe.Text = TieuDe;
            IdTruongThayDoi = IdTruong;
            if(TieuDe=="Tạo trường thay đổi thông tin")
            {
                tb_TenTruong.Text = "";
            }
            else
            {
                tb_TenTruong.Text = TenTruong;
            }
            frmThemMoi = frm;
        }

        private void Rectangle_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.Visibility = Visibility.Collapsed;
        }

        private void btnClose_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            this.Visibility = Visibility.Collapsed;
        }

        private void btnHuy_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            this.Visibility = Visibility.Collapsed;
        }
        
        public string TenTruong = "";

        private void btnDongY_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if(textTieuDe.Text=="Tạo trường thay đổi thông tin")
            {
                TenTruong = tb_TenTruong.Text;
                string MaTruong = "";
                MaTruong = "HDB-" + DateTime.Now.Day.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Year.ToString() + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString() + "VN";
                string str = "";
                foreach (var item in frmThemMoi.lstTuTimKiem)
                {
                    str = str + item + ",";
                }
                str = str.Remove(str.Length - 1);
                clsTruongThayDoi.Data ttd = new clsTruongThayDoi.Data();
                ttd.IdTruong = MaTruong;
                ttd.TenTruong = tb_TenTruong.Text;
                ttd.TuTK = frmThemMoi.TuTimKiem;
                ttd.ViTriThayDoi = str;
                ttd.lstViTri = frmThemMoi.lstVT;
                ttd.TruongMacDinh = "0";
                frmThemMoi.lstTruongThayDoi.Add(ttd); 
                frmThemMoi.lstTruongThayDoi = frmThemMoi.lstTruongThayDoi.ToList();
                frmThemMoi.lsvTruongThayDoi.ItemsSource = frmThemMoi.lstTruongThayDoi;
                this.Visibility = Visibility.Collapsed;
            }
            else
            {
                foreach(clsTruongThayDoi.Data data in frmThemMoi.lstTruongThayDoi)
                {
                    if (data.IdTruong == IdTruongThayDoi)
                    {
                        data.TenTruong = tb_TenTruong.Text;
                        string str = "";
                        foreach (var item in frmThemMoi.lstTuTimKiem)
                        {
                            str = str + item + ",";
                        }
                        str = str.Remove(str.Length - 1);
                        data.ViTriThayDoi = str;
                    }
                }
                //frmThemMoi.lstTruongThayDoi.Add(cls);
                frmThemMoi.lstTruongThayDoi = frmThemMoi.lstTruongThayDoi.ToList();
                frmThemMoi.lsvTruongThayDoi.ItemsSource = frmThemMoi.lstTruongThayDoi;
                this.Visibility = Visibility.Collapsed;
            }
        }
        
    }
}
