using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WhoVisitMyWebSite.Models;
using PagedList;

namespace WhoVisitMyWebSite.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        public ActionResult Index(int? page)
        {
            var clients = db.Clients.OrderByDescending(c => c.Timestamp);
            var pageNumber = page ?? 1;
            var onePageOfClinets = clients.ToPagedList(pageNumber, 25);
            return View(onePageOfClinets);
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

        public ActionResult CheckIn()
        {
            string clientIP = Request.UserHostAddress;
            Client client = new Client();
            client.IP = clientIP;
            client.Timestamp = DateTime.Now;
            client.Name = "Unknown";
            db.Clients.Add(client);
            db.SaveChangesAsync();
            return View();
        }

        [HttpPost]
        public ActionResult CheckIn(Client client)
        {
            
            string clientIP = Request.UserHostAddress;
            client.IP = clientIP;
            client.Timestamp = DateTime.Now;
            db.Clients.Add(client);
            db.SaveChangesAsync();

            return View();
        }


        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}