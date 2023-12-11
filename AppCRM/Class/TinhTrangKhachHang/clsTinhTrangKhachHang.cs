using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace AppCRM.Views.KhachHang.TinhTrangKhachHang
{
    public class clsTinhTrangKhachHang
    {
        public class Datum: INotifyPropertyChanged
        {
            public event PropertyChangedEventHandler PropertyChanged;
            protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
            {
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
            public string stt_id { get; set; }
            public string stt_name { get; set; }
            public string com_id { get; set; }
            public string created_user { get; set; }
            public string type_created { get; set; }

            public int _status;
            public int status { get => _status; set { _status = value; OnPropertyChanged(); } }
            public string is_delete { get; set; }
            public string created_at { get; set; }
            public string updated_at { get; set; }
            public string nguoi_tao { get; set; }
        }

        public class Root
        {
            public bool result { get; set; }
            public string message { get; set; }
            public List<Datum> data { get; set; }
            public int count { get; set; }
        }

    }
}
