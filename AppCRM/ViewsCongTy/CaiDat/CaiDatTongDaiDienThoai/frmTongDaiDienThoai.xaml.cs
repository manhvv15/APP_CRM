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

namespace AppCRM.Views.CaiDat.CaiDatTongDaiDienThoai
{
    /// <summary>
    /// Interaction logic for frmTongDaiDienThoai.xaml
    /// </summary>
    public partial class frmTongDaiDienThoai : Window
    {
        private Model.APIEntity.DataLogin_Employee DataEmp;
        public frmTongDaiDienThoai(Model.APIEntity.DataLogin_Employee dtE)
        {
            InitializeComponent();
            DataEmp = dtE;
        }

        private void btnKetNoiTongĐaiienThoai_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            frmKetNoiTongDaiDienThoai frm = new frmKetNoiTongDaiDienThoai(DataEmp);
            pnlHienThi.Children.Clear();
            object content = frm.Content;
            frm.Content = null;
            frm.Close();
            pnlHienThi.Children.Add(content as UIElement);
        }
    }
}
