using NC.SPENDCS.Models;

namespace NC.SPENDCS.Services
{
    public interface IAdmonService
    {
        Task<AdmonRes> FillUser(string IDUser);
        Task<AdmonRes> ConsAdmonSpend(string IDUser);
        Task<AdmonRes> Guardar(Admon oAdmon);
        Task<AdmonRes> Borrar(Admon oAdmon);
    }
}
