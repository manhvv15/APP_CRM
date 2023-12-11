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
    /// Interaction logic for ChienDich.xaml
    /// </summary>
    public partial class ChienDich : Page
    {
        public ChienDich()
        {
            this.DataContext = this;
            InitializeComponent();
        }
        public List<string> LayDuLieuChienDich { get; set; } = new List<string>()
        {
            "456564465","49879789","221879131","6+f56+f+","98f798g7"
        };
    }
}
