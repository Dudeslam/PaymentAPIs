using NetsEasyPOC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NetsEasyPOC.BusinessLayer;
using PoCNetsEasy.Models;
using PoCNetsEasy.BusinessLayer;

namespace NetsEasyPOC.Controllers
{
    public class HomeController : Controller
    {

        
        NetsClient client = new NetsClient();
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
            return View();
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
            var model = client.CreatePayment(rootBody);
            
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