using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppCRM.Views.CaiDat.QuyTrinhBanHang
{
    public class clsQuyTrinhBanHang
    {
        public class Datum
        {
            public string stt { get; set; }
            public string id { get; set; }
            public string order { get; set; }
            public string name_process { get; set; }
            public string success_rate { get; set; }
            public string forecast_type { get; set; }
            public string forecast_classification { get; set; }
        }

        public class Root
        {
            public bool result { get; set; }
            public string message { get; set; }
            public List<Datum> data { get; set; }
        }
    }
}
