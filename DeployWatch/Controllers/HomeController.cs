using System.Web.Mvc;

namespace DeployWatch.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "DeployWatch";
            return View();
        }
    }
}
