using System;
using System.Collections.Generic;
using System.Linq;
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

namespace AppCRM.ViewsNhanVien.KhachHang.DanhSachKhachHang.ChiTietKhachHang.Popup
{
    /// <summary>
    /// Interaction logic for PopUpTuThayThe.xaml
    /// </summary>
    public partial class PopUpTuThayThe : UserControl
    {
        private frmThemMoiHopDongBan frmThemMoi;
        private string IdTruongTT = "";
        public PopUpTuThayThe(frmThemMoiHopDongBan frm, string Id,string TuCanThay,string TuSeThay)
        {
            InitializeComponent();
            this.DataContext = this;
            IdTruongTT = Id;
            textTuThayThe.Text = TuCanThay;
            textTuSeThayThe.Text = TuSeThay;
            frmThemMoi = frm;
            
        }

        private void Rectangle_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.Visibility = Visibility.Collapsed;
        }

        private void btnHuy_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            this.Visibility = Visibility.Collapsed;
        }

        private void btnDongY_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            foreach (Class.HopDong.clsTruongThayTheFormHD.List lst in frmThemMoi.lstList)
            {
                if (lst.id == IdTruongTT)
                {
                    lst.tuthaythe = textTuSeThayThe.Text;
                }
            }
            frmThemMoi.lstList = frmThemMoi.lstList.ToList();
            frmThemMoi.lsvTruongTD.ItemsSource = frmThemMoi.lstList;
            this.Visibility = Visibility.Collapsed;
        }

        private void btnClose_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            this.Visibility = Visibility.Collapsed;
        }
    }
}
