using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRMS.Entities.ViewModels
{
    public class MstDivisionVM
    {
        public int DivisionId { get; set; }
        public string DivisionNameEng { get; set; }
        public string? DivisionNameHin { get; set; }
        public string DivisionCode { get; set; }
        public bool IsActive { get; set; }
        public string StateNameEng { get; set; } // State Name from MstState
        public short StateId { get; set; }   // For Create/Dropdown
    }
}
