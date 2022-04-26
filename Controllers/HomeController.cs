using NetsEasyPOC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using NetsEasyPOC.BusinessLayer;
using PoCNetsEasy.Models;
using PoCNetsEasy.BusinessLayer;
using System.Reflection;

namespace NetsEasyPOC.Controllers
{
    public class HomeController : Controller
    {

        
        NetsClient NetsClient = new NetsClient();
        BamboraClient BamboraClient = new BamboraClient();
        public ActionResult Index()
        {            //add random products to model
            return View();
        }
        
        public ActionResult Shop()
        {
            var products = new List<Product>();
            products = RandomData.GetRandomProducts();
            Products model = new Products();
            foreach (var item in products)
            {
                model.Add(item);
            }
            return View(model);

        }

        public ActionResult BamboraSession()
        {
            var Model = new BamboraResponse();
            Meta meta = new Meta();
            PoCNetsEasy.Models.Action act = new PoCNetsEasy.Models.Action();
            Message msg = new Message();
            var order = new order();

            
            order.id = RandomData.GetRandomString(10);
            order.currency = "DKK";
            order.amount = "100";
            var Respons = BamboraClient.CreateSession(order);

            //Dynamic Method
            //foreach (var item in Respons.meta)
            //{
            //    foreach (var MetaItem in Model.meta.GetType().GetProperties())
            //    {
            //        if (item.Key == MetaItem.Name)
            //        {
            //            MetaItem.SetValue(Model.meta, item.Value);
            //            //meta.Add(item.Key, item.Value);
            //            //Model.meta.
            //        }
            //    }
            //}

            //Static Method
            Model.meta.result = Respons.meta.result;
            Model.meta.message.merchant = Respons.meta.message.merchant;
            Model.meta.message.enduser = Respons.meta.message.enduser;
            Model.meta.action.code = Respons.meta.action.code;
            Model.meta.action.source = Respons.meta.action.source;
            Model.meta.action.type = Respons.meta.action.type;

            Model.token = Respons.token;
            Model.url = Respons.url;

            return View(Model);
        }
        
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult TestPayment()
        {
            Root rootBody = new Root();
            APIResponse Respo = new APIResponse();

            //Example for testing
            Order TestOrder = new Order();
            TestOrder.amount = 2;
            TestOrder.currency = "DKK";

            Item singleitem = new Item();
            singleitem.reference = "Test";
            singleitem.name = "Test";
            singleitem.quantity = 1;
            singleitem.unitPrice = 100;
            singleitem.unit = "kg";
            singleitem.grossTotalAmount = (singleitem.unitPrice * singleitem.quantity)*1.25;
            singleitem.netTotalAmount = singleitem.unitPrice * singleitem.quantity;
            TestOrder.items.Add(singleitem);
            TestOrder.items.Add(singleitem);
            rootBody.order = TestOrder;
            var model = NetsClient.CreatePayment(rootBody);
            
            return View(model);
        }

        public ActionResult Terms()
        {
            return View();
        }

        public ActionResult Node()
        {
            return View();
        }

        public ActionResult checkout()
        {
            return View();
        }

        public ActionResult Completed()
        {
            return View();
        }

        public ActionResult Bambora()
        {
            var randomID = RandomData.GetRandomString(10);
            var thisString = new RandomString();
            thisString.ThisString = randomID;
            return View(thisString);
        }

    }
}