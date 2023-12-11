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
    /// Interaction logic for ComboboxMangXaHoi.xaml
    /// </summary>
    public partial class ComboboxMangXaHoi : UserControl,INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public ComboboxMangXaHoi()
        {
            InitializeComponent();
            this.DataContext = this;
            test = clsBien.listMangXaHoi;
        }

        private List<object> _test = new List<object>();

        public List<object> test
        {
            get { return _test; }
            set { _test = value; OnPropertyChanged(); }
        }

        
        private void Border_MouseLeftButtonUp_1(object sender, MouseButtonEventArgs e)
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

        private void cbx_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {
            string[] Ten = cbx.SelectedItem.ToString().Split(Convert.ToChar(":"));
            string ten2 = Ten[Ten.Length - 1];
            test.Add(ten2);
            test = test.ToList();
            clsBien.listMangXaHoi.Add(ten2);
            if(ten2==" Zalo")
            {
                clsBien.listIDMangXaHoi.Add("1");
            }
            if (ten2 == " Facebook")
            {
                clsBien.listIDMangXaHoi.Add("2");
            }
            if (ten2 == " Telegram")
            {
                clsBien.listIDMangXaHoi.Add("3");
            }
            if (ten2 == " Twitter")
            {
                clsBien.listIDMangXaHoi.Add("4");
            }
            if (ten2 == " Skype")
            {
                clsBien.listIDMangXaHoi.Add("5");
            }
            if (ten2 == " Instagram")
            {
                clsBien.listIDMangXaHoi.Add("6");
            }
            if (ten2 == " Linkedin")
            {
                clsBien.listIDMangXaHoi.Add("7");
            }
            if (ten2 == " Tiktok")
            {
                clsBien.listIDMangXaHoi.Add("8");
            }
            if (ten2 == " Youtube")
            {
                clsBien.listIDMangXaHoi.Add("9");
            }
        }

        private void btnXoaPB_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            string item = (sender as Border).DataContext as string;
            test.Remove(item);
            test = test.ToList();
            clsBien.listMangXaHoi.Remove(item);
        }
    }
}
