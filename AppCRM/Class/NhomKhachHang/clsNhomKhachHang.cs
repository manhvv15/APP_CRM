using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace AppCRM.Views.KhachHang.NhomKhachHang
{
    
    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
    public class clsNhomKhachHang: INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        public string gr_id { get; set; }
        public string gr_name { get; set; }
        public string gr_description { get; set; }
        public string group_parent { get; set; }
        public string company_id { get; set; }
        public string dep_id { get; set; }
        public string emp_id { get; set; }
        public string count_customer { get; set; }
        public string is_delete { get; set; }
        public string created_at { get; set; }
        public string updated_at { get; set; }
        public List<ListsChildCustomer> lists_child { get; set; }
        private int _isClick = 0;
        public int isClick { get => _isClick; set { _isClick = value; OnPropertyChanged(); } }
    }

    public class ListsChildCustomer
    {
        public string gr_id { get; set; }
        public string gr_name { get; set; }
        public string gr_description { get; set; }
        public string group_parent { get; set; }
        public string company_id { get; set; }
        public string dep_id { get; set; }
        public string emp_id{ get; set; }
        public string count_customer { get; set; }
        public string is_delete { get; set; }
        public string created_at { get; set; }
        public string updated_at { get; set; }
        
    }

    public class RootCustomer
    {
        public bool result { get; set; }
        public string message { get; set; }
        public List<clsNhomKhachHang> data { get; set; }
        public int count { get; set; }
    }
    

}
