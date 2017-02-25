using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Spider.Controllers
{
    public class StratageController : Controller
    {
        // GET: Stratage
        public ActionResult Query()
        {
            return View();
        }

        public ActionResult QueryStratage()
        {
            var testData = new
            {
                records = new object[]
                {
                    new {Name="zheng",Country="China"}
                }
            };
            return Content(Globals.JsonToString(testData));
        }
    }
}