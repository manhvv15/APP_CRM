using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppCRM.Views.HopDong
{
    public class clsTimKiemTu
    {
        // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
        public class Data
        {
            public string sess_id { get; set; }
            public int number_text { get; set; }
            public List<string> image { get; set; }
        }

        public class Root
        {
            public bool result { get; set; }
            public string message { get; set; }
            public Data data { get; set; }
        }


    }
}
