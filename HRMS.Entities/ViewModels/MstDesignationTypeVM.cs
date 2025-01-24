using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRMS.Entities.ViewModels
{
    public class MstDesignationTypeVM
    {
        [Key]
        public int DesignationTypeId { get; set; }
        [Display(Name = "Designation Type(In English)")]
        public string? DesignationTypeNameEng { get; set; }
        [Display(Name = "पदनाम नाम(हिंदी में)")]
        public string? DesignationTypeNameHin { get; set; }
        [Display(Name = "Designation Type Code No")]
        public string? DesignationTypeCode { get; set; }
        [DisplayName("Is Active")]
        public bool IsActive { get; set; } = true;
    }
}
