using Microsoft.ServiceBus.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebRole1.Models;

namespace WebRole1.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return RedirectToAction("Submit");
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Submit()
        {
            var namespaceManager = Connector.CreateNamespaceManager();

            var queue = namespaceManager.GetQueue(Connector.QueueName);

            ViewBag.MessageCount = queue.MessageCount;

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Submit(DeliveryModel order)
        {
            if (ModelState.IsValid)
            {
                var message = new BrokeredMessage(order);
                Connector.OrdersQueueClient.Send(message);
                return RedirectToAction("Submit");

            }
            else
            {
                return View(order);
            }
        }
    }
}