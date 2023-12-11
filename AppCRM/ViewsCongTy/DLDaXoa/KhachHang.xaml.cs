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

namespace AppCRM.Views.DLDaXoa
{
    /// <summary>
    /// Interaction logic for KhachHang.xaml
    /// </summary>
    public partial class KhachHang : Page
    {
        public KhachHang()
        {
            this.DataContext = this;
            InitializeComponent();
        }

        public List<string> LayDuLieuKH { get; set; } = new List<string>()
        {
            "123456","abccccccc","bbbbbbbbb","ccccccccccccc","dddddddddddd","eeeeeeeeeeeee"
        };
    }
}
