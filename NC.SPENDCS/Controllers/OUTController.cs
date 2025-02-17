
using Microsoft.AspNetCore.Mvc;

namespace NC.SPENDCS.Controllers
{
    public class OUTController : Controller
    {
        public IActionResult Index()
        {
            var cookieOptions = new CookieOptions
            {
                HttpOnly = false,
                Expires = DateTime.Now.AddDays(-1),
                IsEssential = false
            };
            foreach (var cookie in Request.Cookies.Keys)
            {
                Response.Cookies.Append(cookie, "", cookieOptions);
                Response.Cookies.Delete(cookie);                
            }
            this.Dispose(); GC.SuppressFinalize(this); GC.Collect(); GC.WaitForPendingFinalizers();
            return View();
        }
    }
}
