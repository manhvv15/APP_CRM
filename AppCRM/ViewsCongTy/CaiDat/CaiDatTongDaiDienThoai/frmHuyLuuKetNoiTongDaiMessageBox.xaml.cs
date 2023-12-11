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

namespace AppCRM.Views.CaiDat.CaiDatTongDaiDienThoai
{
    /// <summary>
    /// Interaction logic for frmHuyLuuKetNoiTongDaiMessageBox.xaml
    /// </summary>
    public partial class frmHuyLuuKetNoiTongDaiMessageBox : Window
    {
        public frmHuyLuuKetNoiTongDaiMessageBox()
        {
            InitializeComponent();
        }

        private void btnHuy_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            this.Close();
        }
    }
}
