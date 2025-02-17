
namespace NC.SPENDCS.Services
{
    public interface IService_API
    {
        Task Autenticar();
        Task<int> Validar(string User, string Password);
        Task<HttpClient> TfnClientApi();
    }
}
