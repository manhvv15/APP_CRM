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
    /// Interaction logic for frmSMSBrandName.xaml
    /// </summary>
    public partial class frmSMSBrandName : Window
    {
        public frmSMSBrandName()
        {
            InitializeComponent();
            textSMSCaNhan.Foreground = Brushes.DarkBlue;
            lineSMSlCN.Stroke = Brushes.DarkBlue;
            textSMSHeThong.Foreground = Brushes.LightSlateGray;
            lineSMSHeThong.Stroke = Brushes.LightSlateGray;
            frmSMSCaNhan frm = new frmSMSCaNhan();
            pnlHienThi.Children.Clear();
            object content = frm.Content;
            frm.Content = null;
            frm.Close();
            pnlHienThi.Children.Add(content as UIElement);
        }

        private void textSMSCaNhan_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            textSMSCaNhan.Foreground = Brushes.DarkBlue;
            lineSMSlCN.Stroke = Brushes.DarkBlue;
            textSMSHeThong.Foreground = Brushes.LightSlateGray;
            lineSMSHeThong.Stroke = Brushes.LightSlateGray;
            frmSMSCaNhan frm = new frmSMSCaNhan();
            pnlHienThi.Children.Clear();
            object content = frm.Content;
            frm.Content = null;
            frm.Close();
            pnlHienThi.Children.Add(content as UIElement);
        }

        private void textSMSHeThong_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            textSMSCaNhan.Foreground = Brushes.LightSlateGray;
            lineSMSlCN.Stroke = Brushes.LightSlateGray;
            textSMSHeThong.Foreground = Brushes.DarkBlue;
            lineSMSHeThong.Stroke = Brushes.DarkBlue;
            frmSMSCaNhan frm = new frmSMSCaNhan();
            pnlHienThi.Children.Clear();
            object content = frm.Content;
            frm.Content = null;
            frm.Close();
            pnlHienThi.Children.Add(content as UIElement);
        }
    }
}
