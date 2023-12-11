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

namespace AppCRM.Views.KhachHang.TinhTrangKhachHang
{
    /// <summary>
    /// Interaction logic for frmDemo.xaml
    /// </summary>
    public partial class frmDemo : Window
    {
        private List<clsTinhTrangKhachHang.Datum> _dt = new List<clsTinhTrangKhachHang.Datum>();
        public frmDemo(List<clsTinhTrangKhachHang.Datum> ls)
        {
            InitializeComponent();
            dt = ls;
        }

        public List<clsTinhTrangKhachHang.Datum> dt { get => _dt; set => _dt = value; }
    }
}
