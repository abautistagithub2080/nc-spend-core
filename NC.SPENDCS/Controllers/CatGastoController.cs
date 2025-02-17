using Microsoft.AspNetCore.Mvc;
using NC.SPENDCS.Models;
using NC.SPENDCS.Services;
using NC.SPENDCS.Tools;
namespace NC.SPENDCS.Controllers
{
    public class CatGastoController : Controller
    {
        private ICatGastosService? _serviceApi;
        public CatGastoController(ICatGastosService servicioApi)
        {
            _serviceApi = servicioApi;
        }
        public async Task<IActionResult> Index()
        {
            CatGastosRes oCatGasto = new CatGastosRes();
            var WIDUsr = Request.Cookies["IDUsr"];
            var oCbxGastos = await _serviceApi.LLenaGastos(WIDUsr, "0");            
            Combo cbx = new Combo();
            var CbxItems = await cbx.FNLLenaCombo(oCbxGastos.LCBXGastos, "IDGastos", "Gastos");
            oCatGasto.LCBGastos = CbxItems;
            return View(oCatGasto);
        }
        [HttpPost]
        public async Task<ActionResult> ConsCatGas(IFormCollection oForm)
        {
            string WIDGas = oForm["HDcbxGas"].ToString();
            if (WIDGas == "") WIDGas = "0";
            CatGastosRes oGastos = new CatGastosRes();
            var WIDUsr = Request.Cookies["IDUsr"];
            var oCbxGastos = await _serviceApi.LLenaGastos(WIDUsr, WIDGas);
            Combo cbx = new Combo();
            var CbxItems = await cbx.FNLLenaCombo(oCbxGastos.LCBXGastos, "IDGastos", "Gastos");
            oGastos.LCBGastos = CbxItems;
            oGastos.Gastos = oCbxGastos.Gastos;
            oGastos.IDGastos = oCbxGastos.IDGastos;
            return View("Index", oGastos);
        }
        [HttpPost]
        public async Task<ActionResult> Guardar(IFormCollection oForm)
        {
            CatGastos oCatGastos = new CatGastos();
            oCatGastos.IDGastos =  int.Parse(oForm["HDcbxGas"].ToString());
            oCatGastos.Gastos = oForm["txtGas"].ToString();
            oCatGastos.IDUsr = int.Parse(Request.Cookies["IDUsr"]);
            var Res = await _serviceApi.Guardar(oCatGastos);
            Combo cbx = new Combo();
            var CbxItems = await cbx.FNLLenaCombo(Res.LCBXGastos, "IDGastos", "Gastos");
            Res.LCBGastos = CbxItems;
            return RedirectToAction("Index", "CatGasto");
        }
        [HttpPost]
        public async Task<ActionResult> Borrar(IFormCollection oForm)
        {
            CatGastos oCatGastos = new CatGastos();
            oCatGastos.IDGastos = int.Parse(oForm["HDcbxGas"].ToString());
            oCatGastos.IDUsr = int.Parse(Request.Cookies["IDUsr"]);
            var Res = await _serviceApi.Borrar(oCatGastos);
            Combo cbx = new Combo();
            var CbxItems =await cbx.FNLLenaCombo(Res.LCBXGastos, "IDGastos", "Gastos");
            Res.LCBGastos = CbxItems;
            return RedirectToAction("Index", "CatGasto");
        }
    }
}
