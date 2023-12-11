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
    /// Interaction logic for QLNhomSP.xaml
    /// </summary>
    public partial class QLNhomSP : Page
    {
        public QLNhomSP()
        {
            this.DataContext = this;
            InitializeComponent();
        }

        public List<string> LayDLDSNhomSP { get; set; } = new List<string>()
        {
            "435jkl","34k2j5kl4","23k14lj3"
        };

        private void Popup_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            popup1.IsOpen = true;
        }

        private void Border_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (popup1.IsOpen == true)
                popup1.IsOpen = false;
        }
    }
}
