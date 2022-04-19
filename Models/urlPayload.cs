using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PoCNetsEasy.Models
{
    public class urlPayload
    {
        string acceptURL { get; set; }
        Data data { get; set; }
    }

    public class Data
    {
        public string status { get; set; }
        public string txnid { get; set; }
        string subscriptionid { get; set; }
        public string orderid { get; set; }
        string reference { get; set; }
        public string amount { get; set; }
        string currency { get; set; }
        public string date { get; set; }
        string time { get; set; }
        string feeid { get; set; }
        string txnfee { get; set; }
        public string paymenttype { get; set; }
        string cardno { get; set; }
        string expmonth { get; set; }
        string expyear { get; set; }
        string eci { get; set; }
        public string issuercountry { get; set; }
        string hash { get; set; }
    }
}