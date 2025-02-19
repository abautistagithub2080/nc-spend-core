using NC.SPENDCS.Models;
using Newtonsoft.Json;

namespace NC.SPENDCS.Services
{
    public class AsignService: IAsignService
    {
        private IService_API _ServiceAPI;
        public AsignService(IService_API serviceAPI)
        {
            _ServiceAPI = serviceAPI;
        }
        public async Task<AdmonRes> FillUser(string IDUser)
        {
            await _ServiceAPI.Autenticar();
            var Client = await _ServiceAPI.TfnClientApi();
            AdmonRes oAdmon = new AdmonRes();
            var response = await Client.GetAsync($"/api/Admon/GetAdmonSpend/{IDUser}");
            if (response.IsSuccessStatusCode)
            {
                var JSON_Res = await response.Content.ReadAsStringAsync();
                var oRes = JsonConvert.DeserializeObject<AdmonRes>(JSON_Res);
                oAdmon.IDUsr = oRes.IDUsr;
                oAdmon.LCBXUsr = oRes.LCBXUsr;
                oAdmon.Nombre = oRes.Nombre;
            }
            return oAdmon;
        }

        public async Task<MenusRes> FillMenu(string IDUser)
        {
            await _ServiceAPI.Autenticar();
            var Client = await _ServiceAPI.TfnClientApi();
            MenusRes oMenu = new MenusRes();   
            var response = await Client.GetAsync($"/api/ROT/FillMenu/{IDUser}");
            if (response.IsSuccessStatusCode)
            {
                var JSON_Res = await response.Content.ReadAsStringAsync();
                var oRes = JsonConvert.DeserializeObject<MenusRes>(JSON_Res);
                oMenu.Menus = oRes.Menus;
                oMenu.NombreUsuario = oRes.NombreUsuario;
                oMenu.mensaje = oRes.mensaje;
            }
            return oMenu;
        }

    }
}
