using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PoCNetsEasy.Models
{
    public class APIResponse
    {
        public string status { get; set; }
        public string message { get; set; }
        public string data { get; set; }
    }
}