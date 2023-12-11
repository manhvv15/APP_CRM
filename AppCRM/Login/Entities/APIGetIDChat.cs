using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppCRM.Login.Entities
{
    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
    public class DataGetIDChat
    {
        public bool result { get; set; }
        public UserGetIDChat user { get; set; }
    }

    public class ErrorGetIDChat
    {
        public int code { get; set; }
        public string message { get; set; }
    }

    public class APIGetIDChat
    {
        public DataGetIDChat data { get; set; }
        public Error error { get; set; }
    }

    public class UserGetIDChat
    {
        public int _id { get; set; }
    }
}
