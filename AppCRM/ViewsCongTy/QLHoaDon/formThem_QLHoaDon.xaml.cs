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

namespace AppCRM.Views.QLHoaDon
{
    /// <summary>
    /// Interaction logic for formThem_QLHoaDon.xaml
    /// </summary>
    public partial class formThem_QLHoaDon : Page
    {
        public formThem_QLHoaDon()
        {
            this.DataContext = this;
            InitializeComponent();
        }
        public List<string> LayDuLieu { get; set; } = new List<string>()
        {
            "564fd56f4","5f4f6545","87d8f977"
        };
    }
}
