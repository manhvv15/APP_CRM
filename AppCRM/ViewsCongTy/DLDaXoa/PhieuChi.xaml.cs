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
    /// Interaction logic for PhieuChi.xaml
    /// </summary>
    public partial class PhieuChi : Page
    {
        public PhieuChi()
        {
            this.DataContext = this;
            InitializeComponent();
        }
        public List<string> LayDLPhieuChi { get; set; } = new List<string>()
        {
            "43k2j5lk23j5","kj5kl3j2l5k","kj3lk4jl3k2","5k3jj25l12j4","klj35kllkjkl"
        };
    }
}
