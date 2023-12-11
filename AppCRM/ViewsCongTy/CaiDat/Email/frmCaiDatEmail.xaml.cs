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

namespace AppCRM.Views.CaiDat.Email
{
    /// <summary>
    /// Interaction logic for frmCaiDatEmail.xaml
    /// </summary>
    public partial class frmCaiDatEmail : Window
    {
        public frmCaiDatEmail()
        {
            InitializeComponent();
            textEmailCaNhan.Foreground = Brushes.DarkBlue;
            lineEmailCN.Stroke = Brushes.DarkBlue;
            textEmailHeThong.Foreground = Brushes.LightSlateGray;
            lineEmailHeThong.Stroke = Brushes.LightSlateGray;
            textEmailMarketing.Foreground = Brushes.LightSlateGray;
            lineEmailMarketing.Stroke = Brushes.LightSlateGray;
            EmailCaNhan.frmThietLapEmailCaNhan frm = new EmailCaNhan.frmThietLapEmailCaNhan();
            pnlHienThi.Children.Clear();
            object content = frm.Content;
            frm.Content = null;
            frm.Close();
            pnlHienThi.Children.Add(content as UIElement);
        }

        private void textEmailCaNhan_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            textEmailCaNhan.Foreground = Brushes.DarkBlue;
            lineEmailCN.Stroke = Brushes.DarkBlue;
            textEmailHeThong.Foreground = Brushes.LightSlateGray;
            lineEmailHeThong.Stroke = Brushes.LightSlateGray;
            textEmailMarketing.Foreground = Brushes.LightSlateGray;
            lineEmailMarketing.Stroke = Brushes.LightSlateGray;
            EmailCaNhan.frmThietLapEmailCaNhan frm = new EmailCaNhan.frmThietLapEmailCaNhan();
            pnlHienThi.Children.Clear();
            object content = frm.Content;
            frm.Content = null;
            frm.Close();
            pnlHienThi.Children.Add(content as UIElement);
        }

        private void textEmailMarketing_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            textEmailCaNhan.Foreground = Brushes.LightSlateGray;
            lineEmailCN.Stroke = Brushes.LightSlateGray;
            textEmailHeThong.Foreground = Brushes.LightSlateGray;
            lineEmailHeThong.Stroke = Brushes.LightSlateGray;
            textEmailMarketing.Foreground = Brushes.DarkBlue;
            lineEmailMarketing.Stroke = Brushes.DarkBlue;
            EmailMaketting.frmEmailMaketting frm = new EmailMaketting.frmEmailMaketting();
            pnlHienThi.Children.Clear();
            object content = frm.Content;
            frm.Content = null;
            frm.Close();
            pnlHienThi.Children.Add(content as UIElement);
        }

        private void textEmailHeThong_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            textEmailCaNhan.Foreground = Brushes.LightSlateGray;
            lineEmailCN.Stroke = Brushes.LightSlateGray;
            textEmailHeThong.Foreground = Brushes.DarkBlue;
            lineEmailHeThong.Stroke = Brushes.DarkBlue;
            textEmailMarketing.Foreground = Brushes.LightSlateGray;
            lineEmailMarketing.Stroke = Brushes.LightSlateGray;
            EmailHeThong.frmThietLapEmailHeThong frm = new EmailHeThong.frmThietLapEmailHeThong();
            pnlHienThi.Children.Clear();
            object content = frm.Content;
            frm.Content = null;
            frm.Close();
            pnlHienThi.Children.Add(content as UIElement);
        }
    }
}
