using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppCRM.Class.HopDong
{
    public class clsXemTruocHopDong
    {
        // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
        public class Data
        {
            public List<string> img_org_base64 { get; set; }
        }

        public class Root
        {
            public bool result { get; set; }
            public string message { get; set; }
            public Data data { get; set; }
        }


    }
}
