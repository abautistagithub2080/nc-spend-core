using Microsoft.AspNetCore.Mvc.Rendering;

namespace NC.SPENDCS.Models
{
    public class AsignRes: Asign
    {
        public List<SelectListItem>? LCBXUser { get; set; }
        public List<SelectListItem>? LCBXMenu { get; set; }
        public IEnumerable<Asign>? IEnumAsig { get; set; }
    }
}
