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
using System.Windows.Forms;

namespace AppCRM.Views.CaiDat.Email.EmailCaNhan
{
    /// <summary>
    /// Interaction logic for frmThietLapEmail.xaml
    /// </summary>
    public partial class frmThietLapEmail : Window
    {
        public frmThietLapEmail(string KetNoi)
        {
            InitializeComponent();
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
            EmailCaNhan.frmThietLapEmailCaNhan frm = new EmailCaNhan.frmThietLapEmailCaNhan();
            frm.tblKetNoi.Text = "Đã kết nối";
            frm.tblKetNoi.Foreground = Brushes.Green;
            frm.btnKetNoi.BorderBrush = Brushes.Green;
            pnlHienThi.Children.Clear();
            object content = frm.Content;
            frm.Content = null;
            frm.Close();
            
            pnlHienThi.Children.Add(content as UIElement);
        }

        private void btnHuyKetNoi_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            EmailCaNhan.frmThietLapEmailCaNhan frm = new EmailCaNhan.frmThietLapEmailCaNhan();
            frm.tblKetNoi.Text = "Kết nối";
            frm.tblKetNoi.Foreground = Brushes.Blue;
            frm.btnKetNoi.BorderBrush = Brushes.Blue;
            pnlHienThi.Children.Clear();
            object content = frm.Content;
            frm.Content = null;
            frm.Close();
            
            pnlHienThi.Children.Add(content as UIElement);
        }
    }
}
