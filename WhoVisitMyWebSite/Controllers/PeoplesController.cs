using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WhoVisitMyWebSite.Controllers
{
    public class PeoplesController : Controller
    {
        //
        // GET: /Peoples/
        public JsonResult Index()
        {
            List<People> dumData = new List<People>();
            int count = 10;
            for (int i = 0; i < count; i++)
            {
                dumData.Add(new People 
                {
                    FirstName = "John " + i,
                    LastName = "Qu",
                    Telephone = "15895326302",
                    Male = (i%2 == 0)
                
                });
            }
            return Json(dumData, JsonRequestBehavior.AllowGet);
        }


        class People
        {
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public string Telephone { get; set; }
            public bool Male { get; set; }
        }
	}
}