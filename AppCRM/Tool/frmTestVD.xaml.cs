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
using System.Windows.Shapes;
using System.Windows.Threading;

namespace AppCRM.Tool
{
    /// <summary>
    /// Interaction logic for frmTestVD.xaml
    ///public </summary>
     partial class frmTestVD : UserControl
    {
        public frmTestVD()
        {
            InitializeComponent();
            this.DataContext = this;
        }
        private bool fullscreen = false;
        private DispatcherTimer DoubleClickTimer = new DispatcherTimer();
        private void minionPlayer_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (!DoubleClickTimer.IsEnabled)
            {
                DoubleClickTimer.Start();
            }
            else
            {
                if (!fullscreen)
                {
                    Window wd = new Window();
                    wd.Content = this;
                    wd.WindowStyle = WindowStyle.None;
                    wd.WindowState = WindowState.Maximized;
                }
                else
                {
                    Window wd = new Window();
                    wd.Content = this;
                    wd.WindowStyle = WindowStyle.None;
                    wd.WindowState = WindowState.Maximized;
                }

                fullscreen = !fullscreen;
            }
        }
    }
}
