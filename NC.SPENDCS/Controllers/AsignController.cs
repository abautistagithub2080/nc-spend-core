using Microsoft.AspNetCore.Mvc;
using NC.SPENDCS.Models;
using NC.SPENDCS.Services;
using NC.SPENDCS.Tools;

namespace NC.SPENDCS.Controllers
{
    public class AsignController : Controller
    {

        private IAsignService? _serviceApi;
        public AsignController(IAsignService servicioApi)
        {
            _serviceApi = servicioApi;
        }

        public async Task<IActionResult> Index()
        {
            var WIDUsrGlobal = Request.Cookies["IDUsr"];
            var oAdmon = await _serviceApi.FillUser(WIDUsrGlobal);
            AsignRes oAsigRes = new AsignRes();
            Combo cbx = new Combo();
            var CbxItems = await cbx.FNLLenaCombo(oAdmon.LCBXUsr, "IDUsr", "NomCom");
            oAsigRes.LCBXUser = CbxItems;
            cbx = null;


            var oMenu = await _serviceApi.FillMenu(WIDUsrGlobal);


            return View(oAsigRes);
        }
    }
}
