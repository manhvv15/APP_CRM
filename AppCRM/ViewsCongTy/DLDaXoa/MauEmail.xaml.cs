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
    /// Interaction logic for MauEmail.xaml
    /// </summary>
    public partial class MauEmail : Page
    {
        public MauEmail()
        {
            this.DataContext = this;
            InitializeComponent();
        }

        public List<string> LayDuLieuMauEmail { get; set; } = new List<string>()
        {
            "312k3ljl","32kj4kl2","kj43lk2j4l"
        };
    }
}
