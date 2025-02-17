using NC.SPENDCS.Models;

namespace NC.SPENDCS.Services
{
    public interface ICatGastosService
    {
        Task<ROT> LLenaMenus(string IDUser);
        Task<CatGastosRes> LLenaGastos(string IDUser, string IDGastos);
        Task<CatGastosRes> Guardar(CatGastos oSpend);
        Task<CatGastosRes> Borrar(CatGastos oSpend);
    }
}
