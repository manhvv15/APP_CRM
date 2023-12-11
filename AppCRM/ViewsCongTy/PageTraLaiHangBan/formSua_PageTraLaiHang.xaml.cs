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
    /// Interaction logic for formSua_PageTraLaiHang.xaml
    /// </summary>
    public partial class formSua_PageTraLaiHang : Page
    {
        public formSua_PageTraLaiHang()
        {
            this.DataContext = this;
            InitializeComponent();
        }
        public List<string> LayThongTinHangHoa = new List<string>()
        {
            "54564564","878978979","321231564"
        };
    }
}
