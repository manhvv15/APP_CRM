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

namespace AppCRM.Views.PageTraLaiHangBan
{
    /// <summary>
    /// Interaction logic for formThem_PageTraLaiHang.xaml
    /// </summary>
    public partial class formThem_PageTraLaiHang : Page
    {
        public formThem_PageTraLaiHang()
        {
            this.DataContext = this;
            InitializeComponent();
        }
        public List<string> LayThongTinHangHoa { get; set; } = new List<string>()
        {
            "54654654","987821132","23312345648"
        };
    }
}
