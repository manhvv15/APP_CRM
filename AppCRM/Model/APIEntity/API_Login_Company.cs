﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace AppCRM.Model.APIEntity
{
    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
    public class DataLogin_Company
    {
        public string com_id { get; set; }
        public string com_name { get; set; }
        public string com_phone { get; set; }
        public string com_logo { get; set; }
        public string com_address { get; set; }
        public string com_authentic { get; set; }
        public string com_email { get; set; }
        public string token { get; set; }
        public string ToMD5(string str)
        {
            MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
            byte[] bHash = md5.ComputeHash(Encoding.UTF8.GetBytes(str));
            StringBuilder sbHash = new StringBuilder();
            foreach (byte b in bHash)
            {
                sbHash.Append(String.Format("{0:x2}", b));
            }
            return sbHash.ToString();
        }
        public string pass { get; set; }
        public string message { get; set; }
    }

    public class API_Login_Company
    {
        public bool result { get; set; }
        public int code { get; set; }
        public DataLogin_Company data { get; set; }
        public object error { get; set; }
    }
}
