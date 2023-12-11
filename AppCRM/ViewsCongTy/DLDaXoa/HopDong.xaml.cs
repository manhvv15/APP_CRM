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
    /// Interaction logic for HopDong.xaml
    /// </summary>
    public partial class HopDong : Page
    {
        public HopDong()
        {
            this.DataContext = this;
            InitializeComponent();
        }

        public List<string> LayDuLieuHopDong { get; set; } = new List<string>()
        {
            "987f987f9","767668ff","98f09809f","32984kj2","23ui4j32k"
        };



    }
}
