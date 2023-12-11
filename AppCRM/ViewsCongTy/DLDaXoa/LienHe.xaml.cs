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
    /// Interaction logic for LienHe.xaml
    /// </summary>
    public partial class LienHe : Page
    {
        public LienHe()
        {
            this.DataContext = this;
            InitializeComponent();
        }

        public List<string> LayDuLieuLienHe { get; set; } = new List<string>()
        {
            "aaaaaaaaaaa","bbbbbbbbbb","cccccccccc","ddddddddddd","111111111111","22222222222"
        };
    }
}
