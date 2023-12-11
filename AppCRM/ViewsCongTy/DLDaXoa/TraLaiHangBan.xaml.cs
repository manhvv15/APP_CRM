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
    /// Interaction logic for TraLaiHangBan.xaml
    /// </summary>
    public partial class TraLaiHangBan : Page
    {
        public TraLaiHangBan()
        {
            this.DataContext = this;
            InitializeComponent();
        }
        public List<string> LayDLTraLaiHangBan { get; set; } = new List<string>()
        {
            "5612132164","9789871546","213265464","87894421323"
        };
    }
}
