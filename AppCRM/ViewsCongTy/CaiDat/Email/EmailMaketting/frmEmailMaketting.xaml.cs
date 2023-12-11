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

namespace AppCRM.Views.CaiDat.Email.EmailMaketting
{
    /// <summary>
    /// Interaction logic for frmEmailMaketting.xaml
    /// </summary>
    public partial class frmEmailMaketting : Window
    {
        public frmEmailMaketting()
        {
            InitializeComponent();
        }

        private void btnKetNoiZetaMail_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            frmZetamail frm = new frmZetamail();
            pnlHienThi.Children.Clear();
            object content = frm.Content;
            frm.Content = null;
            frm.Close();
            pnlHienThi.Children.Add(content as UIElement);
        }

        private void btnKetNoiMailChimp_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            frmMailChimp frm = new frmMailChimp();
            pnlHienThi.Children.Clear();
            object content = frm.Content;
            frm.Content = null;
            frm.Close();
            pnlHienThi.Children.Add(content as UIElement);
        }

        private void btnKetNoiGetRespose_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            frmGetResponse frm = new frmGetResponse();
            pnlHienThi.Children.Clear();
            object content = frm.Content;
            frm.Content = null;
            frm.Close();
            pnlHienThi.Children.Add(content as UIElement);
        }
    }
}
