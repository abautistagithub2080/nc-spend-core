using NC.SPENDCS.Models;
using Newtonsoft.Json;
using System.Text;
namespace NC.SPENDCS.Services
{
    public class CatGastosService: ICatGastosService
    {
        private IService_API _ServiceAPI;
        public CatGastosService(IService_API serviceAPI)
        {
            _ServiceAPI = serviceAPI;
        }
        public async Task<ROT> LLenaMenus(string IDUser)
        {
            await _ServiceAPI.Autenticar();
            var Client = await _ServiceAPI.TfnClientApi();
            ROT oMenu = new ROT();
            var response = await Client.GetAsync($"/api/ROT/FillMenu/{IDUser}");
            if (response.IsSuccessStatusCode)
            {
                var json_respuesta = await response.Content.ReadAsStringAsync();
                var oRes = JsonConvert.DeserializeObject<MenusRes>(json_respuesta);
                oMenu.IEnumMenus = oRes.Menus;
                oMenu.NombreUsuario = oRes.NombreUsuario;
            }
            return oMenu;
        }
        public async Task<CatGastosRes> LLenaGastos(string IDUser, string IDGastos)
        {
            await _ServiceAPI.Autenticar();
            var Client = await _ServiceAPI.TfnClientApi();
            CatGastosRes oCatGastos = new CatGastosRes();
            var response = await Client.GetAsync($"/api/CatGastos/GetCatSpend/{IDUser}/{IDGastos}");
            if (response.IsSuccessStatusCode)
            {
                var json_respuesta = await response.Content.ReadAsStringAsync();
                var oRes = JsonConvert.DeserializeObject<CatGastosRes>(json_respuesta);
                oCatGastos.IDGastos = oRes.IDGastos;
                oCatGastos.LCBXGastos = oRes.LCBXGastos;
                oCatGastos.Gastos = oRes.Gastos;
            }
            return oCatGastos;
        }
        public async Task<CatGastosRes> Guardar(CatGastos oSpend)
        {
            await _ServiceAPI.Autenticar();
            var client = await _ServiceAPI.TfnClientApi();
            CatGastosRes oCatGastos = new CatGastosRes();
            var content = new StringContent(JsonConvert.SerializeObject(oSpend), Encoding.UTF8, "application/json");
            var response = await client.PostAsync("api/CatGastos/Guardar/", content);
            if (response.IsSuccessStatusCode)
            {
                var json_respuesta = await response.Content.ReadAsStringAsync();
                var oRes = JsonConvert.DeserializeObject<CatGastosRes>(json_respuesta);
                oCatGastos.IDGastos = oRes.IDGastos;
                oCatGastos.LCBXGastos = oRes.LCBXGastos;
                oCatGastos.Gastos = oRes.Gastos;
            }
            return oCatGastos;
        }
        public async Task<CatGastosRes> Borrar(CatGastos oSpend)
        {
            await _ServiceAPI.Autenticar();
            var client = await _ServiceAPI.TfnClientApi();
            CatGastosRes oCatGastos = new CatGastosRes();
            var content = new StringContent(JsonConvert.SerializeObject(oSpend), Encoding.UTF8, "application/json");
            var response = await client.PostAsync("api/CatGastos/Borrar/", content);
            if (response.IsSuccessStatusCode)
            {
                var json_respuesta = await response.Content.ReadAsStringAsync();
                var oRes = JsonConvert.DeserializeObject<CatGastosRes>(json_respuesta);
                oCatGastos.IDGastos = oRes.IDGastos;
                oCatGastos.LCBXGastos = oRes.LCBXGastos;
                oCatGastos.Gastos = oRes.Gastos;
            }
            return oCatGastos;
        }
    }
}
