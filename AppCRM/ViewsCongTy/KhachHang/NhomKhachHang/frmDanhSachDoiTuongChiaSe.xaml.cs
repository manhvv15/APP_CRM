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

namespace AppCRM.Views.KhachHang.NhomKhachHang
{
    /// <summary>
    /// Interaction logic for frmDanhSachDoiTuongChiaSe.xaml
    /// </summary>
    public partial class frmDanhSachDoiTuongChiaSe : Window
    {
        
        private List<string> _listPB = new List<string>();
        private List<string> _lstNhanVien = new List<string>();
        private List<string> _test = new List<string>();
        private List<List<string>> _lsnv = new List<List<string>>();
        private List<List<string>> _kfc = new List<List<string>>();
        private List<Item> _listPhongBan = new List<Item>();
        private List<clsNhanVien.Item> _listNV = new List<clsNhanVien.Item>();
        public frmDanhSachDoiTuongChiaSe(List<string> lstIdPhongBan, List<Item> lstpb, List<clsNhanVien.Item> oopNV)
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
        
        public List<string> ListPB { get => _listPB; set => _listPB = value; }
        public List<clsNhanVien.Item> ListNV { get => _listNV; set => _listNV = value; }
        public List<Item> ListPhongBan { get => _listPhongBan; set => _listPhongBan = value; }
        public List<string> LstNhanVien { get => _lstNhanVien; set => _lstNhanVien = value; }
        public List<List<string>> Lsnv { get => _lsnv; set => _lsnv = value; }
        public List<List<string>> Kfc { get => _kfc; set => _kfc = value; }
        public List<string> Test { get => _test; set => _test = value; }

        private void btnClose_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            this.Close();
        }
    }
}
