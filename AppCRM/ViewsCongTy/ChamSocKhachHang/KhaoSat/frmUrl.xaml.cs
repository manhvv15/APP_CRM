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

namespace AppCRM.Views.ChamSocKhachHang.KhaoSat
{
    /// <summary>
    /// Interaction logic for frmUrl.xaml
    /// </summary>
    public partial class frmUrl : Window
    {
        public frmUrl()
        {
            InitializeComponent();
        }

        private void btnGui_MouseEnter(object sender, MouseEventArgs e)
        {
            btnGui.Background = Brushes.BlueViolet;
            tblGui.Foreground = Brushes.White;
        }

        private void btnGui_MouseLeave(object sender, MouseEventArgs e)
        {
            btnGui.Background = Brushes.Transparent;
            tblGui.Foreground = Brushes.BlueViolet;
        }
    }
}
