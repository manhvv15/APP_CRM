using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
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

namespace AppCRM.Tool
{
    /// <summary>
    /// Interaction logic for ComboboxDanhSachNhanVienThuocCongTy.xaml
    /// </summary>
    public partial class ComboboxDanhSachNhanVienThuocCongTy : UserControl,INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        public ComboboxDanhSachNhanVienThuocCongTy()
        {
            InitializeComponent();
            this.DataContext = this;
            lstNhanVienThuocCongTy = clsBien.lstNhanVienThuocCongTy;
        }
        private static List<object> _lstNhanVienThuocCongTy = new List<object>();

        public List<object> lstNhanVienThuocCongTy { get => _lstNhanVienThuocCongTy; set { _lstNhanVienThuocCongTy = value; OnPropertyChanged(); } }

        private void cbx_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void btnXoaNV_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {

        }

        private void Border_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (cbx.IsDropDownOpen == false)
            {
                cbx.IsDropDownOpen = true;
            }
            else
            {
                cbx.IsDropDownOpen = false;
            }
        }
    }
}
