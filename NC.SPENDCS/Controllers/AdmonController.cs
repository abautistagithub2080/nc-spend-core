using Microsoft.AspNetCore.Mvc;
using NC.SPENDCS.Models;
using NC.SPENDCS.Services;
using NC.SPENDCS.Tools;

namespace NC.SPENDCS.Controllers
{
    public class AdmonController : Controller
    {
        private IAdmonService? _serviceApi;
        public AdmonController(IAdmonService servicioApi)
        {
            _serviceApi = servicioApi;
        }
        public async Task<IActionResult> Index()
        {
            var WIDUsrGlobal = Request.Cookies["IDUsr"];
            var oAdmon = await _serviceApi.FillUser(WIDUsrGlobal);
            AdmonRes oAdmonRes = new AdmonRes();
            oAdmonRes.IDUsr = 0;
            oAdmonRes.Nombre = ""; oAdmonRes.Paterno = ""; oAdmonRes.Materno = "";
            oAdmonRes.Usuario = ""; oAdmonRes.Password = "";
            Combo cbx = new Combo();
            var CbxItems = await cbx.FNLLenaCombo(oAdmon.LCBXUsr, "IDUsr", "NomCom");
            oAdmonRes.LCBUsr = CbxItems;
            cbx = null;
            return View(oAdmonRes);
        }
        [HttpPost]
        public async Task<ActionResult> ConsAdmon(IFormCollection oForm)
        {
            AdmonRes oAdmonRes = new AdmonRes();
            var WIDUsr = oForm["HDcbxAdmon"].ToString();
            if (WIDUsr == "") WIDUsr = "0";
            var oAdmon = await _serviceApi.ConsAdmonSpend(WIDUsr);
            Combo cbx = new Combo();
            var CbxItems = await cbx.FNLLenaCombo(oAdmon.LCBXUsr, "IDUsr", "NomCom");
            oAdmonRes.LCBUsr = CbxItems;
            oAdmonRes.IDUsr = int.Parse(WIDUsr);
            oAdmonRes.Nombre = oAdmon.Nombre;
            oAdmonRes.Paterno = oAdmon.Paterno;
            oAdmonRes.Materno = oAdmon.Materno;
            oAdmonRes.Usuario = oAdmon.Usuario;
            oAdmonRes.Password = oAdmon.Password;
            return View("Index",oAdmonRes);
        }

        [HttpPost]
        public async Task<ActionResult> Guardar(IFormCollection oForm)
        {
            //AdmonRes oAdmonRes = new AdmonRes();
            var WIDUsr = oForm["HDcbxAdmon"].ToString();
            var WIDUsrGlobal = Request.Cookies["IDUsr"];
            Admon oAdmon = new Admon();
            oAdmon.IDUsr = int.Parse(oForm["HDcbxAdmon"].ToString());

            oAdmon.Nombre = oForm["txtNom"].ToString();
            oAdmon.Paterno = oForm["txtPaterno"].ToString(); 
            oAdmon.Materno = oForm["txtMaterno"].ToString();
            oAdmon.Usuario = oForm["txtUsuario"].ToString(); 
            oAdmon.Password = oForm["txtContra"].ToString();
            var oAdmonR = await _serviceApi.Guardar(oAdmon);
            Combo cbx = new Combo();
            var CbxItems = await cbx.FNLLenaCombo(oAdmonR.LCBXUsr, "IDUsr", "NomCom");
            oAdmonR.LCBUsr = CbxItems;
            return RedirectToAction("Index", "Admon");            
        }

        [HttpPost]
        public async Task<ActionResult> Borrar(IFormCollection oForm)
        {
            AdmonRes oAdmonRes = new AdmonRes();
            var WIDUsr = oForm["HDcbxAdmon"].ToString();
            var WIDUsrGlobal = Request.Cookies["IDUsr"];
            Admon oAdmon = new Admon();
            oAdmon.IDUsr = int.Parse(oForm["HDcbxAdmon"].ToString());
            var oAdmonR = await _serviceApi.Borrar(oAdmon);
            return RedirectToAction("Index", "Admon");
        }



    }
}
