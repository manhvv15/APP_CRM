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

namespace AppCRM.Views.CaiDat.SMSBrandName
{
    /// <summary>
    /// Interaction logic for frmSMSCaNhan.xaml
    /// </summary>
    public partial class frmSMSCaNhan : Window
    {
        public frmSMSCaNhan()
        {
            InitializeComponent();
        }

        private void btnKetNoiVTH_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            KetNoiSMSBrandName frm = new KetNoiSMSBrandName(tblKetNoiVTH.Text, textKetNoiVTH.Text);
            pnlHienThi.Children.Clear();
            object content = frm.Content;
            frm.Content = null;
            frm.Close();
            pnlHienThi.Children.Add(content as UIElement);
        }

        private void btnKetNoiSTelecom_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            KetNoiSMSBrandName frm = new KetNoiSMSBrandName(tblKetNoiStelecom.Text, textKetNoiSTelecom.Text);
            pnlHienThi.Children.Clear();
            object content = frm.Content;
            frm.Content = null;
            frm.Close();
            pnlHienThi.Children.Add(content as UIElement);
        }

        private void btnKetNoiCMC_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            KetNoiSMSBrandName frm = new KetNoiSMSBrandName(tblKetNoiCMC.Text, textKetNoiCMC.Text);
            pnlHienThi.Children.Clear();
            object content = frm.Content;
            frm.Content = null;
            frm.Close();
            pnlHienThi.Children.Add(content as UIElement);
        }

        private void btnKetNoiViettel_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            KetNoiSMSBrandName frm = new KetNoiSMSBrandName(tblKetNoiViettel.Text, textKetNoiViettel.Text);
            pnlHienThi.Children.Clear();
            object content = frm.Content;
            frm.Content = null;
            frm.Close();
            pnlHienThi.Children.Add(content as UIElement);
        }

        private void btnKetNoiFPT_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            KetNoiSMSBrandName frm = new KetNoiSMSBrandName(tblKetNoiFPT.Text, textKetNoiFPT.Text);
            pnlHienThi.Children.Clear();
            object content = frm.Content;
            frm.Content = null;
            frm.Close();
            pnlHienThi.Children.Add(content as UIElement);
        }
    }
}
