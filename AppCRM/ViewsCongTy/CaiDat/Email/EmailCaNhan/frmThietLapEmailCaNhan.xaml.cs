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

namespace AppCRM.Views.CaiDat.Email.EmailCaNhan
{
    /// <summary>
    /// Interaction logic for frmThietLapEmailCaNhan.xaml
    /// </summary>
    public partial class frmThietLapEmailCaNhan : Window
    {
        public frmThietLapEmailCaNhan()
        {
            InitializeComponent();
        }

        
        private void btnKetNoi_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if(tblKetNoi.Text=="Kết nối")
            {
                frmThietLapEmail frm = new frmThietLapEmail(tblKetNoi.Text);
                pnlHienThi.Children.Clear();
                object content = frm.Content;
                frm.Content = null;
                frm.Close();
                pnlHienThi.Children.Add(content as UIElement);
            }
            else if(tblKetNoi.Text == "Đã kết nối")
            {
                frmThietLapEmail frm = new frmThietLapEmail(tblKetNoi.Text);
                pnlHienThi.Children.Clear();
                object content = frm.Content;
                frm.Content = null;
                frm.Close();
                pnlHienThi.Children.Add(content as UIElement);
                

            }
        }
    }
}
