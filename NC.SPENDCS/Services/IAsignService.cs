using NC.SPENDCS.Models;

namespace NC.SPENDCS.Services
{
    public interface IAsignService
    {
        Task<AdmonRes> FillUser(string IDUser);
        Task<MenusRes> FillMenu(string IDUser);
    }
}
