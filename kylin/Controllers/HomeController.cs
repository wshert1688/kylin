using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using kylin.DB;

namespace kylin.Controllers {
    public class HomeController : Controller {
        public ActionResult Index() {
            //var result = DBProvider.GetArticle(1, 1, 1);
            //var a = DBProvider.GetArticle(1);
            return View();
        }
        public ActionResult Article(int aid) {
            return View();
        }
    }
}
