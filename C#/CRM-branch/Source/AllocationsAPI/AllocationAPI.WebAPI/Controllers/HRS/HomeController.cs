using System.Web.Http.Cors;
using System.Web.Mvc;

namespace AllocationsAPI.WebAPI.Controllers.HRS
{
    /// <summary>
    /// </summary>
    [EnableCors("*", "*", "*")]
    [System.Web.Http.RoutePrefix("api/HRS")]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "Welcome to allocations api";

            return View("Index");
        }
    }
}