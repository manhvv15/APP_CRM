using AppCRM.Views.KhachHang.NhomKhachHang;
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

namespace AppCRM.ViewsNhanVien.KhachHang.NhomKhachHang.PopUp
{
    /// <summary>
    /// Interaction logic for PopUpDanhSachDoiTuongDuocChiaSe.xaml
    /// </summary>
    public partial class PopUpDanhSachDoiTuongDuocChiaSe : UserControl
    {
        private List<clsNhanVien.Item> ListNV = new List<clsNhanVien.Item>();
        public PopUpDanhSachDoiTuongDuocChiaSe(List<string> IdPB, List<clsNhanVien.Item> oopNV)
        {
            InitializeComponent();
            this.DataContext = this;
            //ListPhongBan = lstpb;
            //foreach (Item it in lstpb)
            //{
            //    foreach (string idPB in lstIdPhongBan)
            //    {
            //        if (idPB.Equals(it.dep_id))
            //        {
            //            ListPB.Add(it.dep_name);
            //        }
            //    }
            //}
            //LstNhanVien.Clear();
            //foreach (string idPB in lstIdPhongBan)
            //{

            //    foreach (clsNhanVien.Item item in oopNV)
            //    {
            //        if (idPB == item.dep_id)
            //        {
            //            LstNhanVien.Add(item.ep_name);
            //        }
            //    }
            //    Lsnv.Add(LstNhanVien);
            //}
            ListNV = oopNV;
            //Kfc =new List<List<string>>() { new List<string>() { "aaa", "bbb" }, new List<string>() { "dd", "ee" } };
            //for (int i = 0; i < Kfc.Count; i++)
            //{
            //    Test = Kfc[i];
            //}
            lvUsers.ItemsSource = ListNV;
            CollectionView view = (CollectionView)CollectionViewSource.GetDefaultView(ListNV);
            PropertyGroupDescription groupDescription = new PropertyGroupDescription("dep_name");
            view.GroupDescriptions.Add(groupDescription);

        }

        private void Rectangle_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.Visibility = Visibility.Collapsed;
        }

        private void btnClose_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            this.Visibility = Visibility.Collapsed;
        }
    }
}
