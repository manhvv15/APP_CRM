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
    /// Interaction logic for ChinhSachGia.xaml
    /// </summary>
    public partial class ChinhSachGia : Page
    {
        public ChinhSachGia()
        {
            this.DataContext = this;
            InitializeComponent();
        }

        public List<string> LayDuLieuChinhSachGia { get; set; } = new List<string>()
        {
            "432klj5l23","3k24j5lk","k3j452lk","3k4l2j5kl"
        };
    }
}
