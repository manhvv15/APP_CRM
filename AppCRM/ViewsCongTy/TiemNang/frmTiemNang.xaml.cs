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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace AppCRM.Views.TiemNang
{
    /// <summary>
    /// Interaction logic for frmTiemNang.xaml
    /// </summary>
    public partial class frmTiemNang : Page
    {
        public frmTiemNang()
        {
            InitializeComponent();
        }

        private void btnThemMoi_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            frmThemMoiTiemNang frm = new frmThemMoiTiemNang();
            pnlHienThi.Children.Clear();
            object content = frm.Content;
            frm.Content = null;
            //frm.Close();
            pnlHienThi.Children.Add(content as UIElement);
        }
    }
}
