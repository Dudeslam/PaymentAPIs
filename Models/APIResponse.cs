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

    public class BamboraResponse
    {
        public Meta meta { get; set; } = new Meta();
        public string token { get; set; } = "";
        public string url { get; set; } = "";
    }

    public class Action
    {
        public string code { get; set; } = "";
        public string source { get; set; } = "";
        public string type { get; set; } = "";
    }

    public class Message
    {
        public string enduser { get; set; } = "";
        public string merchant { get; set; } = "";
    }

    public class Meta
    {
        public Action action { get; set; } = new Action();
        public Message message { get; set; } = new Message();
        public bool result { get; set; } = false;
    }
}