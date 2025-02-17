using Microsoft.AspNetCore.Mvc;
using NC.SPENDCS.Models;
using NC.SPENDCS.Services;
using System.Globalization;

namespace NC.SPENDCS.Controllers
{
    public class AccController : Controller
    {
        private IService_API? _serviceApi;
        public AccController(IService_API servicioApi)
        {
            _serviceApi = servicioApi;
        }
        public IActionResult Index()
        {
            Usuario oUser = new Usuario();
            oUser.nPaso = 0; oUser.User = "";
            return View(oUser);
        }
        [HttpPost]
        public async Task<ActionResult> Valida(IFormCollection oCollec)
        { 
            string WUser = oCollec["txtUsr"].ToString(); string WContra = oCollec["txtContra"].ToString();
            int nValida = await _serviceApi.Validar(WUser, WContra);
            SPLlenaCookies(nValida);
            oCollec = null;
            if (nValida == 0)
            {
                Usuario oValida = new Usuario();
                oValida.nPaso = 1; oValida.User = WUser; oValida.Password = WContra;
                return View("Index", oValida);
            }
            else
            {
                return RedirectToAction("Index", "ROT");
            }
        }
        private void SPLlenaCookies(int nValida) {
            var cookieOptions = new CookieOptions
            {
                HttpOnly = true,
                Expires = DateTime.Now.AddDays(1),
                IsEssential = true
            };
            Response.Cookies.Append("IDUsr", nValida.ToString(), cookieOptions);
        }      
    }
}
