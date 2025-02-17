using Microsoft.AspNetCore.Mvc.Rendering;

namespace NC.SPENDCS.Models
{
    public class AdmonRes: Admon
    {
        public List<Admon>? LCBXUsr { get; set; }
        public List<SelectListItem>? LCBUsr { get; set; }
    }
}
