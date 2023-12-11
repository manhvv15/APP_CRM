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

namespace AppCRM.Views.ChamSocKhachHang.TongDai
{
    /// <summary>
    /// Interaction logic for frmTongDai.xaml
    /// </summary>
    public partial class frmTongDai : Page
    {
        private frmTrangChuSauDangNhapCongTy frmMain;
        public frmTongDai(frmTrangChuSauDangNhapCongTy frm)
        {
            InitializeComponent();
            frmMain = frm;
        }

        private void btnKetNoiTongDai_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            frmMain.pnlShowPopup.Children.Add(new frmKetNoiTongDai());
            //frmKetNoiTongDai frm=new frmKetNoiTongDai();
            //frm.ShowDialog();
        }
    }
}
