using Common;
using Model;
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

        private int? staId { get; set; }
        public int? StaId
        {
            get
            {
                return staId;
            }
            set { staId = value; }
        }

        public ActionResult Edit(int? staid)
        {
            StaId = staId;
            stratege sta = null;
            if (StaId != null)
            {
                sta= new SpiderEntities().
            }
            ViewData["StaId"] = StaId;
            return View();
        }
    }
}