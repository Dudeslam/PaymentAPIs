using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCVueJsApp.Models
{
    public class User
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
    }

    public class IndexViewModel
    {
        public User User { get; set; }
        public List<User> Users { get; set; }

    }
}