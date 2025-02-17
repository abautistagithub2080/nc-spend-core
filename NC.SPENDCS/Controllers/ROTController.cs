using Microsoft.AspNetCore.Mvc;
using NC.SPENDCS.Models;
using NC.SPENDCS.Services;

namespace NC.SPENDCS.Controllers
{
    public class ROTController : Controller
    {

        private ICatGastosService? _serviceApi;
        public ROTController(ICatGastosService servicioApi)
        {
            _serviceApi = servicioApi;
        }
        public async Task<IActionResult> Index()
        {
            ROT oMenus = new ROT();
            var WIDUsr =  Request.Cookies["IDUsr"];            
            var oMenuXUser = await _serviceApi.LLenaMenus(WIDUsr);
            oMenus.NombreUsuario = oMenuXUser.NombreUsuario;
            oMenus.IEnumMenus = oMenuXUser.IEnumMenus;
            oMenuXUser = null;
            return View(oMenus);
        }
    }
}
