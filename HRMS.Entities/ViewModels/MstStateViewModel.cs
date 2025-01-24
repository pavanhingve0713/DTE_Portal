using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace HRMS.Entities.ViewModels
{
    public class MstStateViewModel
    {

        public Int16 StateId { get; set; }

        [StringLength(50)]
        [Unicode(false)]
        [Required(ErrorMessage = "Field is required.")]
        [RegularExpression(@"^[a-zA-Z\s]+$", ErrorMessage = "Use characters only.")]
        [Display(Name = "State Name (In English)")]
        public string StateNameEng { get; set; } = null!;

        [StringLength(60)]
        [Display(Name = "राज्य का नाम (हिंदी में)")]
        [RegularExpression(@"^[\u0900-\u097F\s]+$", ErrorMessage = "राज्य का नाम हिंदी में दर्ज करें।")]
        [Required(ErrorMessage = "कृपया राज्य का नाम दर्ज करे।")]
        public string StateNameHin { get; set; } = null!;

        [StringLength(2)]
        [Unicode(false)]
        [RegularExpression(@"^[0-9]{2}$", ErrorMessage = "Use numeric value only.")]
        [Required(ErrorMessage = "Field is required.")]
        [MinLength(2, ErrorMessage = "Code No. must be at least 2 digit.")]
        [Display(Name = "State Code No.")]
        public string StateCode { get; set; } = null!;

        public bool IsActive { get; set; }
      
    }
}
