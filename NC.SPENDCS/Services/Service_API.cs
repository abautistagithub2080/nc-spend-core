using Microsoft.AspNetCore.Mvc.Rendering;
using NC.SPENDCS.Models;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Text;

namespace NC.SPENDCS.Services
{
    public class Service_API : IService_API
    {

        private static string? _usuario;
        private static string? _clave;
        private static string? _baseUrl;
        private static string? _token;
        public Service_API()
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build();
            _usuario = builder.GetSection("ApiSetting:usuario").Value;
            _clave = builder.GetSection("ApiSetting:clave").Value;
            _baseUrl = builder.GetSection("ApiSetting:baseUrl").Value;
        }
        public async Task Autenticar()
        {
            var Client = new HttpClient();
            Client.BaseAddress = new Uri(_baseUrl);
            var credenciales = new Credencial() { usuario = _usuario, clave = _clave };
            var content = new StringContent(JsonConvert.SerializeObject(credenciales), Encoding.UTF8, "application/json");
            var response = await Client.PostAsync("api/Autenticacion/Validar", content);
            var json_respuesta = await response.Content.ReadAsStringAsync();
            var resultado = JsonConvert.DeserializeObject<ResultadoCredencial>(json_respuesta);
            _token = resultado.token;
        }
        public async Task<int> Validar(string User, string Password)
        {
            int nUser = 0;
            await Autenticar();
            var Client = await TfnClientApi();
            var response = await Client.GetAsync($"/api/Spend/Validar/{User}/{Password}");
            if (response.IsSuccessStatusCode)
            {
                var json_respuesta = await response.Content.ReadAsStringAsync();
                var ResUser = JsonConvert.DeserializeObject<ResultadoApi>(json_respuesta);
                nUser = ResUser.userOK;
            }
            return nUser;
        }
        public async Task<HttpClient> TfnClientApi()
        {
            var cliente = new HttpClient();
            cliente.BaseAddress = new Uri(_baseUrl);
            cliente.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _token);
            return cliente;
        }
    }
}
