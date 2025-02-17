using NC.SPENDCS.Models;
using Newtonsoft.Json;
using System.Text;

namespace NC.SPENDCS.Services
{
    public class AdmonService: IAdmonService
    {
        private IService_API _ServiceAPI;
        public AdmonService(IService_API serviceAPI)
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
        public async Task<AdmonRes> ConsAdmonSpend(string IDUser)
        {
            await _ServiceAPI.Autenticar();
            var Client = await _ServiceAPI.TfnClientApi();
            AdmonRes oAdmon = new AdmonRes();
            var response = await Client.GetAsync($"/api/Admon/GetConsAdmonSpend/{IDUser}");
            if (response.IsSuccessStatusCode)
            {
                var JSON_Res = await response.Content.ReadAsStringAsync();
                var oRes = JsonConvert.DeserializeObject<AdmonRes>(JSON_Res);
                oAdmon.IDUsr = oRes.IDUsr;
                oAdmon.LCBXUsr = oRes.LCBXUsr;
                oAdmon.Nombre = oRes.Nombre;
                oAdmon.Paterno = oRes.Paterno;
                oAdmon.Materno = oRes.Materno;
                oAdmon.Usuario = oRes.Usuario;
                oAdmon.Password = oRes.Password;
            }
            return oAdmon;
        }
        public async Task<AdmonRes> Guardar(Admon oAdmon)
        {
            await _ServiceAPI.Autenticar();
            var client = await _ServiceAPI.TfnClientApi();
            AdmonRes oAdmonRes = new AdmonRes();
            var content = new StringContent(JsonConvert.SerializeObject(oAdmon), Encoding.UTF8, "application/json");
            var response = await client.PostAsync("api/Admon/Guardar/", content);
            if (response.IsSuccessStatusCode)
            {
                var json_respuesta = await response.Content.ReadAsStringAsync();
                var oRes = JsonConvert.DeserializeObject<AdmonRes>(json_respuesta);
                oAdmonRes.LCBXUsr = oRes.LCBXUsr;
            }
            return oAdmonRes;
        }
        public async Task<AdmonRes> Borrar(Admon oAdmon)
        {
            await _ServiceAPI.Autenticar();
            var client = await _ServiceAPI.TfnClientApi();
            AdmonRes oAdmonRes = new AdmonRes();
            var content = new StringContent(JsonConvert.SerializeObject(oAdmon), Encoding.UTF8, "application/json");
            var response = await client.PostAsync("api/Admon/Borrar/", content);
            if (response.IsSuccessStatusCode)
            {
                var json_respuesta = await response.Content.ReadAsStringAsync();
                var oRes = JsonConvert.DeserializeObject<AdmonRes>(json_respuesta);
                oAdmonRes.LCBXUsr = oRes.LCBXUsr;
            }
            return oAdmonRes;
        }
    }
}
