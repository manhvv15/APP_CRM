using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppCRM.Login.Entities
{
    public class APINotification
    {
        public string content { get; set; }
        public string customerName { get; set; }
        public int customerId { get; set; }
        public string groupName { get; set; }
        public string link { get; set; }
        public int type { get; set; }
        public string phone { get; set; }
    }

}
