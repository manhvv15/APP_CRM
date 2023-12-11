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

namespace AppCRM.Views.ChinhSachGia
{
    /// <summary>
    /// Interaction logic for PageChinhSachGia.xaml
    /// </summary>
    public partial class PageChinhSachGia : Page
    {
        public PageChinhSachGia()
        {
            this.DataContext = this;
            InitializeComponent();
        }
        public List<string> LayDLChinhSachGia { get; set; } = new List<string>()
        {
            "6545656","72124"
        };
    }
}
