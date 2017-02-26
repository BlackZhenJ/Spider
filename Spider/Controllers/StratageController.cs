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
        internal StratageModel Model
        {
            get
            {
                return StratageModel.Instanse;
            }
        }
        // GET: Stratage
        public ActionResult Query()
        {
            return View();
        }

        public ActionResult QueryStratage()
        {
            var staLst = Model.GetList();
            return Content(Globals.JsonToString(staLst));
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

        public ActionResult Edit(int? id)
        {
            StaId = id;
            stratege sta = null;
            if (StaId != null)
                sta = StratageModel.Instanse.GetModelById(StaId.Value);
            else
                sta = new stratege();

            ViewData["stratage"] = Globals.JsonToString(sta);

            return View();
        }

        public ActionResult Ajax()
        {
            var method = HttpContext.Request.Form["method"];
            var result = Globals.JsonToString(new
            {
                success = true,
                message = ""
            }); ;

            try
            {
                switch (method)
                {
                    case "Save":
                        result = Save();
                        break;
                    case "Delete":
                        Delete();
                        break;

                }
            }
            catch (Exception e)
            {
                result = Globals.JsonToString(new
                {
                    success = false,
                    message = e.Message
                });
            }

            return Content(result);
        }

        private void Delete()
        {
            var id = HttpContext.Request.Form["id"];

            StratageModel.Instanse.Delete(int.Parse(id));
        }

        private string Save()
        {
            var model = HttpContext.Request.Form["model"];

            var success = true;
            var msg = "";

            StratageModel.Instanse.SaveModel(Globals.StringToJson<stratege>(model));

            return Globals.JsonToString(new
            {
                success = success,
                message = msg
            });

        }
    }
}