﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppCRM.Views.KhachHang.DanhSachKhachHang
{
    public class clsLinhVucKH
    {
        public class Datum
        {
            public int id { get; set; }
            public string value { get; set; }
        }

        public class Root
        {
            public bool result { get; set; }
            public string message { get; set; }
            public List<Datum> data { get; set; }
        }

    }
}
