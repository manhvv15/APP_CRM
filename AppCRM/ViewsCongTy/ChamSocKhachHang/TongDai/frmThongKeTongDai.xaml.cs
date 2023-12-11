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
using System.Windows.Shapes;

namespace AppCRM.Views.ChamSocKhachHang.TongDai
{
    /// <summary>
    /// Interaction logic for frmThongKeTongDai.xaml
    /// </summary>
    public partial class frmThongKeTongDai : Page
    {
        frmThanhMenuDoc frmMain;
        public frmThongKeTongDai(frmThanhMenuDoc frm)
        {
            InitializeComponent();
            frmMain = frm;
        }

        private void btnBoLoc_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            frmMain.pnlShowPopup.Children.Add(new ViewsCongTy.ChamSocKhachHang.TongDai.PopUp.PopUpBoLocThongKe());
            //frmBoLocThongKe frm = new frmBoLocThongKe();
            //frm.ShowDialog();
        }
    }
}
