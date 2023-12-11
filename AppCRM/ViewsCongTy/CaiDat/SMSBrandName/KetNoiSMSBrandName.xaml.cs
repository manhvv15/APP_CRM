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
    /// Interaction logic for KetNoiSMSBrandName.xaml
    /// </summary>
    public partial class KetNoiSMSBrandName : Window
    {
        public KetNoiSMSBrandName(string TieuDe, string KetNoi)
        {
            InitializeComponent();
            textTieuDe.Text = TieuDe;
            if(KetNoi=="Kết nối")
            {
                pnlHuyKetNoi.Visibility = Visibility.Collapsed;
                pnlKetNoi.Visibility = Visibility.Visible;
            }
            else if(KetNoi=="Đã kết nối")
            {
                pnlHuyKetNoi.Visibility = Visibility.Visible;
                pnlKetNoi.Visibility = Visibility.Collapsed;
            }
        }

        private void btnLuu_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (textTieuDe.Text == "VTH")
            {
                frmSMSCaNhan frm = new frmSMSCaNhan();
                pnlHienThi.Children.Clear();
                object content = frm.Content;
                frm.Content = null;
                frm.Close();
                frm.textKetNoiVTH.Text = "Đã kết nối";
                frm.textKetNoiVTH.Foreground = Brushes.Green;
                frm.btnKetNoiVTH.BorderBrush = Brushes.Green;
                pnlHienThi.Children.Add(content as UIElement);
            }
            else if (textTieuDe.Text == "SouthTelecom")
            {
                frmSMSCaNhan frm = new frmSMSCaNhan();
                pnlHienThi.Children.Clear();
                object content = frm.Content;
                frm.Content = null;
                frm.Close();
                frm.textKetNoiSTelecom.Text = "Đã kết nối";
                frm.textKetNoiSTelecom.Foreground = Brushes.Green;
                frm.btnKetNoiSTelecom.BorderBrush = Brushes.Green;
                pnlHienThi.Children.Add(content as UIElement);
            }
            else if (textTieuDe.Text == "CMC")
            {
                frmSMSCaNhan frm = new frmSMSCaNhan();
                pnlHienThi.Children.Clear();
                object content = frm.Content;
                frm.Content = null;
                frm.Close();
                frm.textKetNoiCMC.Text = "Đã kết nối";
                frm.textKetNoiCMC.Foreground = Brushes.Green;
                frm.btnKetNoiCMC.BorderBrush = Brushes.Green;
                pnlHienThi.Children.Add(content as UIElement);
            }
            else if (textTieuDe.Text == "Viettel")
            {
                frmSMSCaNhan frm = new frmSMSCaNhan();
                pnlHienThi.Children.Clear();
                object content = frm.Content;
                frm.Content = null;
                frm.Close();
                frm.textKetNoiViettel.Text = "Đã kết nối";
                frm.textKetNoiViettel.Foreground = Brushes.Green;
                frm.btnKetNoiViettel.BorderBrush = Brushes.Green;
                pnlHienThi.Children.Add(content as UIElement);
            }
            else if (textTieuDe.Text == "FPT")
            {
                frmSMSCaNhan frm = new frmSMSCaNhan();
                pnlHienThi.Children.Clear();
                object content = frm.Content;
                frm.Content = null;
                frm.Close();
                frm.textKetNoiFPT.Text = "Đã kết nối";
                frm.textKetNoiFPT.Foreground = Brushes.Green;
                frm.btnKetNoiFPT.BorderBrush = Brushes.Green;
                pnlHienThi.Children.Add(content as UIElement);
            }
        }

        private void btnHuyKetNoi_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (textTieuDe.Text == "VTH")
            {
                frmSMSCaNhan frm = new frmSMSCaNhan();
                pnlHienThi.Children.Clear();
                object content = frm.Content;
                frm.Content = null;
                frm.Close();
                frm.textKetNoiVTH.Text = "Kết nối";
                frm.textKetNoiVTH.Foreground = Brushes.Blue;
                frm.btnKetNoiVTH.BorderBrush = Brushes.Blue;
                pnlHienThi.Children.Add(content as UIElement);
            }
            else if (textTieuDe.Text == "SouthTelecom")
            {
                frmSMSCaNhan frm = new frmSMSCaNhan();
                pnlHienThi.Children.Clear();
                object content = frm.Content;
                frm.Content = null;
                frm.Close();
                frm.textKetNoiSTelecom.Text = "Kết nối";
                frm.textKetNoiSTelecom.Foreground = Brushes.Blue;
                frm.btnKetNoiSTelecom.BorderBrush = Brushes.Blue;
                pnlHienThi.Children.Add(content as UIElement);
            }
            else if (textTieuDe.Text == "CMC")
            {
                frmSMSCaNhan frm = new frmSMSCaNhan();
                pnlHienThi.Children.Clear();
                object content = frm.Content;
                frm.Content = null;
                frm.Close();
                frm.textKetNoiCMC.Text = "Kết nối";
                frm.textKetNoiCMC.Foreground = Brushes.Blue;
                frm.btnKetNoiCMC.BorderBrush = Brushes.Blue;
                pnlHienThi.Children.Add(content as UIElement);
            }
            else if (textTieuDe.Text == "Viettel")
            {
                frmSMSCaNhan frm = new frmSMSCaNhan();
                pnlHienThi.Children.Clear();
                object content = frm.Content;
                frm.Content = null;
                frm.Close();
                frm.textKetNoiViettel.Text = "Kết nối";
                frm.textKetNoiViettel.Foreground = Brushes.Blue;
                frm.btnKetNoiViettel.BorderBrush = Brushes.Blue;
                pnlHienThi.Children.Add(content as UIElement);
            }
            else if (textTieuDe.Text == "FPT")
            {
                frmSMSCaNhan frm = new frmSMSCaNhan();
                pnlHienThi.Children.Clear();
                object content = frm.Content;
                frm.Content = null;
                frm.Close();
                frm.textKetNoiFPT.Text = "Kết nối";
                frm.textKetNoiFPT.Foreground = Brushes.Blue;
                frm.btnKetNoiFPT.BorderBrush = Brushes.Blue;
                pnlHienThi.Children.Add(content as UIElement);
            }
        }
    }
}
