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
    /// Interaction logic for DonHang.xaml
    /// </summary>
    public partial class DonHang : Page
    {
        
        public DonHang()
        {
            this.DataContext = this;
            InitializeComponent();
        }

        public List<string> LayDuLieuDonHang { get; set; } = new List<string>()
        {
            "11121kjkjlk2","21kj3kl12j3l","34j5k43klj","343lk23j6l4"
        };
    }
}
