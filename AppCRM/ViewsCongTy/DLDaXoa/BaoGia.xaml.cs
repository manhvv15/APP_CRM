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
    /// Interaction logic for BaoGia.xaml
    /// </summary>
    public partial class BaoGia : Page
    {
        public BaoGia()
        {
            this.DataContext = this;
            InitializeComponent();
        }

        public List<string> LayDuLieuBaoGia { get; set; } = new List<string>()
        {
            "1111111","1123123123","22222222","3333333333","44444444444"
        };
    }
}
