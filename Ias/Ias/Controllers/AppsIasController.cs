using System.Linq;
using System.Web.Mvc;
using Google.Protobuf.WellKnownTypes;
using Ias.Models;

namespace Ias.Controllers
{
    public class AppsIasController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            var apps = new AppIas().GetApps();
            return View(apps);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var app = new AppIas().GetApps(id);
            return View(app);
        }

        [HttpPost]
        public ActionResult Edit(AppIas app)
        {
            var result = new AppIas().UpdateApps(app);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Create(AppIas app)
        {
            var result = new AppIas().InsertApps(app);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            var app = new AppIas().GetApps(id);

            return View(app);
        }

        [HttpPost]
        public ActionResult DeletePost(int id)
        {
            var app = new AppIas().DeleteApps(id);

            return RedirectToAction("Index");
        }

    }
}