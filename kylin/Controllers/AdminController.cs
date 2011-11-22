using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using kylin.DB;

namespace kylin.Controllers
{
    public class AdminController : Controller
    {

        public ActionResult Article(int? catID,int? pageIndex)
        {
            ViewBag.result = DBProvider.GetArticle(catID ?? 0, pageIndex ?? 1, 20);
            return View();
        }

    }
}
