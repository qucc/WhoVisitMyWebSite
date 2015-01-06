using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WhoVisitMyWebSite.Controllers
{
    public class IpconfigController : Controller
    {
        //
        // GET: /Ipconfig/
        public string Index()
        {
            return Request.UserHostAddress;
        }
	}
}