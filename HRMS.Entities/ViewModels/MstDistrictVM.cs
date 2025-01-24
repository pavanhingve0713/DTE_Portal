using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRMS.Entities.ViewModels
{
    public class MstDistrictVM
    {
        public int DistrictId { get; set; }      
        public string StateNameEng { get; set; }

        public string DivisionNameEng { get; set; }

        public string DistrictNameEng { get; set; } = null!;

        public string DistrictNameHin { get; set; } = null!;

        public string DistrictCode { get; set; } = null!;

        public bool IsActive { get; set; }
    }
}
