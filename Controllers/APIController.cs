using PoCNetsEasy.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;


namespace PoCNetsEasy.Controllers
{
    public class APIController : Controller
    {
        // GET: API
        public ActionResult Accept()
        {
            var model = new Data();
            PropertyInfo[] fields = typeof(Data).GetProperties(BindingFlags.NonPublic | BindingFlags.Instance);
            foreach (var field in fields)
            {
                field.SetValue(model, Request.QueryString[field.Name]);
            }

            return View(model);
        }

        public ActionResult Cancel()
        {
            return View();
        }
    }
}