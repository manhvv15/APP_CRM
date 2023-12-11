using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppCRM
{
    public class clsThongBao
    {
        public class Data
        {
            public bool result { get; set; }
            public string message { get; set; }
            public List<ListNotification> listNotification { get; set; }
        }

        public class ListNotification
        {
            public string title { get; set; }
            public string message { get; set; }
            public int isUndeader { get; set; }
            public DateTime createAt { get; set; }
            public string type { get; set; }
            public object messageId { get; set; }
            public int conversationId { get; set; }
            public string link { get; set; }
            public string idNotification { get; set; }
            public int userID { get; set; }
            public Participant participant { get; set; }
            public string time { get; set; }
        }

        public class Participant
        {
            public int id { get; set; }
            public string userName { get; set; }
            public string avatarUser { get; set; }
            public DateTime lastActive { get; set; }
        }

        public class Root
        {
            public Data data { get; set; }
            public object error { get; set; }
        }

    }
}
