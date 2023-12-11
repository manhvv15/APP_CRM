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

namespace AppCRM.Views.CaiDat
{
    /// <summary>
    /// Interaction logic for frmCaiDat.xaml
    /// </summary>
    public partial class frmCaiDat : Window
    {
        private Model.APIEntity.DataLogin_Employee DataEmp;
        public frmCaiDat(Model.APIEntity.DataLogin_Employee dtE)
        {
            InitializeComponent();
            DataEmp = dtE;
        }

        private void textQuyTrinhBanHang_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            QuyTrinhBanHang.frmQuyTrinhBanHang frm = new QuyTrinhBanHang.frmQuyTrinhBanHang();
            pnlHienThi.Children.Clear();
            object content = frm.Content;
            frm.Content = null;
            frm.Close();
            pnlHienThi.Children.Add(content as UIElement);
        }

        private void textTongDaiDienThoai_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            CaiDatTongDaiDienThoai.frmTongDaiDienThoai frm = new CaiDatTongDaiDienThoai.frmTongDaiDienThoai(DataEmp);
            pnlHienThi.Children.Clear();
            object content = frm.Content;
            frm.Content = null;
            frm.Close();
            pnlHienThi.Children.Add(content as UIElement);
        }

        private void textEmail_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            CaiDat.Email.frmCaiDatEmail frm = new Email.frmCaiDatEmail();
            pnlHienThi.Children.Clear();
            object content = frm.Content;
            frm.Content = null;
            frm.Close();
            pnlHienThi.Children.Add(content as UIElement);
        }

        private void textSMSBrànName_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            CaiDat.SMSBrandName.frmSMSBrandName frm = new SMSBrandName.frmSMSBrandName();
            pnlHienThi.Children.Clear();
            object content = frm.Content;
            frm.Content = null;
            frm.Close();
            pnlHienThi.Children.Add(content as UIElement);
        }

        private void textWebform_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            CaiDat.Webform.frmWebform frm = new Webform.frmWebform();
            pnlHienThi.Children.Clear();
            object content = frm.Content;
            frm.Content = null;
            frm.Close();
            pnlHienThi.Children.Add(content as UIElement);
        }

        private void textBanGiaoCongViec_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            BanGiaoCongViec.frmBanGiaoCongViec frm = new BanGiaoCongViec.frmBanGiaoCongViec();
            frm.ShowDialog();
        }

        private void textChiaSeKhachHang_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            CaiDat.ChiaSeKhachHang.frmChiaSeKhachHang frm = new ChiaSeKhachHang.frmChiaSeKhachHang();
            pnlHienThi.Children.Clear();
            object content = frm.Content;
            frm.Content = null;
            frm.Close();
            pnlHienThi.Children.Add(content as UIElement);
        }
    }
}
