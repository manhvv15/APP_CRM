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

namespace AppCRM.Views.QuanLyThuChi
{
    /// <summary>
    /// Interaction logic for PhieuThu.xaml
    /// </summary>
    public partial class PhieuThu : Page
    {
        public PhieuThu()
        {
            this.DataContext = this;
            InitializeComponent();
        }
        public List<string> LayDLQuanLyPhieuThu { get; set; } = new List<string>()
        {
            "23k4jk32j4","k34j2kl5","kj45lk36","k3j4524kl"
        };
    }
}
