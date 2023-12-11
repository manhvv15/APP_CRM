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
    /// Interaction logic for PhieuThu.xaml
    /// </summary>
    public partial class PhieuThu : Page
    {
        public PhieuThu()
        {
            this.DataContext = this;
            InitializeComponent();
        }
        public List<string> LayDLPhieuThu { get; set; } = new List<string>()
        {
            "u32i4ou5o3","k43j5kl23j5","k352jl434kj2","2lk3j4lkkl43j5"
        };
    }
}
