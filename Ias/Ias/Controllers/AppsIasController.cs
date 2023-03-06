using System.Linq;
using System.Web.Mvc;
using Ias.Models;

namespace Ias.Controllers
{
    public class AppsIasController : Controller
    {
        // GET
        public ActionResult Index()
        {
            var apps = new AppIas().GetApps();
            return View(apps);
        }

        public ActionResult Edit(int id)
        {
            var apps = new AppIas().GetApps();
            return View(apps.FirstOrDefault(a => a.Id == id));
        }
        
    }
}