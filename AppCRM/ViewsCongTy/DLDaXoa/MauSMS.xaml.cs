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
    /// Interaction logic for MauSMS.xaml
    /// </summary>
    public partial class MauSMS : Page
    {
        public MauSMS()
        {
            this.DataContext = this;
            InitializeComponent();
        }
        public List<string> LayDuLieuMauSMS { get; set; } = new List<string>()
        {
            "43k5lj23k4k5","34kl5l34","3kjk22l3kj5k","3k4j25lk43j"
        };
    }
}
