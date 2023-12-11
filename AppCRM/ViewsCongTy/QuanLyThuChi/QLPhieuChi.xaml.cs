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

namespace AppCRM.Views.QuanLyThuChi
{
    /// <summary>
    /// Interaction logic for QuanLyPhieuChi.xaml
    /// </summary>
    public partial class QuanLyPhieuChi : Page
    {
        public QuanLyPhieuChi()
        {
            this.DataContext = this;
            InitializeComponent();
        }
        public List<string> LayDLQuanLyPhieuChi { get; set; } = new List<string>()
        {
            "34kj5kl34j5","342jlk5j43lk2","21k34jklj","jk3j46klkl","j2k1l34231"
        };
    }
}
