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

namespace AppCRM.Views.CaiDat.BanGiaoCongViec
{
    /// <summary>
    /// Interaction logic for frmBanGiaoCongViec.xaml
    /// </summary>
    public partial class frmBanGiaoCongViec : Window
    {
        public frmBanGiaoCongViec()
        {
            InitializeComponent();
        }

        private void btnHuy_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            this.Close();
        }

        private void btnThoat_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            this.Close();
        }

    }
}
