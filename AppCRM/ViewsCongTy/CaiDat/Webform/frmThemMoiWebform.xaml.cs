using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace AppCRM.Views.CaiDat.Webform
{
    /// <summary>
    /// Interaction logic for frmThemMoiWebform.xaml
    /// </summary>
    public partial class frmThemMoiWebform : Window
    {
        public frmThemMoiWebform()
        {
            InitializeComponent();
        }
        ObservableCollection<string> _lst = new ObservableCollection<string>();
        public ObservableCollection<string> lst { get => _lst; set { _lst = value; } }
        private void txbMoNganHang_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            lst.Add("1");
        }

        private void textXungHo_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            lst.Add("1");
        }

        private void Border_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            frmThemMoiWebformTiepTheo frm = new frmThemMoiWebformTiepTheo();
            pnlHienThi.Children.Clear();
            object content = frm.Content;
            frm.Content = null;
            frm.Close();
            pnlHienThi.Children.Add(content as UIElement);
        }

        private void btnXemTruoc_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            frmTenForm frm = new frmTenForm();
            frm.ShowDialog();
        }
    }
}
