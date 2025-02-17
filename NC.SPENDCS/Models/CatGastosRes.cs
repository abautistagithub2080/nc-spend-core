using Microsoft.AspNetCore.Mvc.Rendering;

namespace NC.SPENDCS.Models
{
    public class CatGastosRes: CatGastos
    {
        public List<CatGastos>? LCBXGastos { get; set; }
        public List<SelectListItem>? LCBGastos { get; set; }
    }
}
