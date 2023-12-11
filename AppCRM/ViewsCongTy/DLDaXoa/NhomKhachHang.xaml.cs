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
    /// Interaction logic for NhomKhachHang.xaml
    /// </summary>
    public partial class NhomKhachHang : Page
    {
        public NhomKhachHang()
        {
            this.DataContext = this;
            InitializeComponent();
        }

        public List<string> LayDuLieuNhomKH { get; set; } = new List<string>()
        {
            "Lịch hẹn - Nguyễn Thị Hòa Nguy",
            "1.000",
            "Nhóm khách hàng rất tiềm năng của công",
            "Nguyễn Văn Hùng",
            "10:10 - 22/03/2022",
        };
    }
}
