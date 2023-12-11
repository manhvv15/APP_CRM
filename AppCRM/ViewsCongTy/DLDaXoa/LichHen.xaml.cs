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
    /// Interaction logic for LichHen.xaml
    /// </summary>
    public partial class LichHen : Page
    {
        public LichHen()
        {
            this.DataContext = this;
            InitializeComponent();
        }

        public List<string> LayDuLieuLichHen { get; set; } = new List<string>()
        {
            "98f77f8998f98dffhjkfuioijkl","908f0989d0f808f080df9","ddfdf8ddofiu98df","doifud97f987dhifh"
        };
    }
}
