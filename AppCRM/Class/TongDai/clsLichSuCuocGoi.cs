using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppCRM.Views.ChamSocKhachHang.TongDai
{
    public class clsLichSuCuocGoi
    {
        public class Item
        {
            public string id { get; set; }
            public string call_id { get; set; }
            public string caller { get; set; }
            public string caller_domain { get; set; }
            public string caller_display_name { get; set; }
            public string callee { get; set; }
            public string callee_domain { get; set; }
            public string final_dest { get; set; }
            public int fail_code { get; set; }
            public string start_time { get; set; }
            public string answer_time { get; set; }
            public string end_time { get; set; }
            public string ringing_time { get; set; }
            public string duration { get; set; }
            public string session_id { get; set; }
            public string related_callid_1 { get; set; }
            public string related_callid_2 { get; set; }
            public string ring_duration { get; set; }
            public string talk_duration { get; set; }
            public string caller_endpoint { get; set; }
            public string callee_endpoint { get; set; }
            public string direction { get; set; }
            public string end_reason { get; set; }
            public string status { get; set; }
            public string outcid { get; set; }
            public string didcid { get; set; }
            public string call_cost { get; set; }
        }

        public class Root
        {
            public List<Item> items { get; set; }
        }
    }
}
