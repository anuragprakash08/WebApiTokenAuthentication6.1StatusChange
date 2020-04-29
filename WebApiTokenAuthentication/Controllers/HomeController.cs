using System.Web.Mvc;

namespace WebApiTokenAuthentication.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "TMS API";

            return View();
        }
    }
}