using Microsoft.AspNetCore.Mvc;

namespace NC.SPENDCS.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
