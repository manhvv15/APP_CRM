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
    /// Interaction logic for LichChamSoc.xaml
    /// </summary>
    public partial class LichChamSoc : Page
    {
        public LichChamSoc()
        {
            this.DataContext = this;
            InitializeComponent();
        }
        public List<string> LayDuLieuLichChamSoc { get; set; } = new List<string>()
        {
            "89f89fg79f8","9fgfoidg987","78f6g876f5g","87fg9f809g","78f6g87f678g"
        };
    }
}
