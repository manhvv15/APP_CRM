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

namespace AppCRM.Views.CaiDat.ChiaSeKhachHang
{
    /// <summary>
    /// Interaction logic for frmChiaSeNhomKhachHang.xaml
    /// </summary>
    public partial class frmChiaSeNhomKhachHang : Window
    {
        public frmChiaSeNhomKhachHang()
        {
            InitializeComponent();
        }

        private void btnHuy_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            this.Close();
        }

        private void btnClose_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            this.Close();
        }
    }
}
