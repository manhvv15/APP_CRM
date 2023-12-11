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

namespace AppCRM.Views.NhaCungCap
{
    /// <summary>
    /// Interaction logic for DSNhomNCC.xaml
    /// </summary>
    public partial class DSNhomNCC : Page
    {
        public DSNhomNCC()
        {
            this.DataContext = this;
            InitializeComponent();
        }
        public List<string> LayDLNhomNCC { get; set; } = new List<string>()
        {
            "8978978","23165112","78946565"
        };
    }
}
