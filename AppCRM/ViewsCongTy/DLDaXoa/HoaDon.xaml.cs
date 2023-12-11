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
    /// Interaction logic for HoaDon.xaml
    /// </summary>
    public partial class HoaDon : Page
    {
        public HoaDon()
        {
            this.DataContext = this;
            InitializeComponent();
        }

        public List<string> LayDuLieuHoaDon { get; set; } = new List<string>()
        {
            "213k213213","213213kjl","56kljkl6","kj98jk78k7l"
        };
    }
}
