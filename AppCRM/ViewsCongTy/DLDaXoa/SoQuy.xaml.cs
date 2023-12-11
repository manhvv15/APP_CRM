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
    /// Interaction logic for SoQuy.xaml
    /// </summary>
    public partial class SoQuy : Page
    {
        public SoQuy()
        {
            this.DataContext = this;
            InitializeComponent();
        }
        public List<string> LayDLSoQuy { get; set; } = new List<string>()
        {
            "3lk2j4lk432","5lk423j5l34j5","kj243j5234l5","k34j26klj45","34k2j5lk34j52"
        };
    }
}
