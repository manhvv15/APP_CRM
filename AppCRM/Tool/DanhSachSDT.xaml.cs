using AppCRM.Views.KhachHang.DanhSachKhachHang.ChiTietKhachHang;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
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
    /// Interaction logic for DanhSachSDT.xaml
    /// </summary>
    public partial class DanhSachSDT : UserControl, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        public DanhSachSDT()
        {
            InitializeComponent();
            this.DataContext = this;
            test = clsBien.listSDT;
            test = test.ToList();
        }
        private List<object> _test = new List<object>();

        public List<object> test
        {
            get { return _test; }
            set { _test = value; OnPropertyChanged(); }
        }
        

        private void textThemSDT_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            test.Add(textSoDienThoai.Text);
            test = test.ToList();
            clsBien.listSDT.Add(textSoDienThoai.Text);
            textSoDienThoai.Text = "";
        }

        private void btnXoaPB_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            string item = (sender as Border).DataContext as string;
            test.Remove(item);
            test = test.ToList();
            clsBien.listSDT.Remove(item);
        }

        private void textSoDienThoai_KeyUp(object sender, KeyEventArgs e)
        {
            if (textSoDienThoai.Text != "")
            {
                if (e.Key == Key.Enter)
                {
                    test.Add(textSoDienThoai.Text);
                    test = test.ToList();
                    clsBien.listSDT.Add(textSoDienThoai.Text);
                    textSoDienThoai.Text = "";
                }
            }
            
        }
    }
}
