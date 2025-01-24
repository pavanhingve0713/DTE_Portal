using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace HRMS.Entities.Models
{
    public class MstCaste
    {
        [Key]
        public int CasteId { get; set; }

        [StringLength(25)]
        [Unicode(false)]
        [Required(ErrorMessage = "Field is required.")]
        [RegularExpression(@"^[a-zA-Z\s\-.\(\)]+$", ErrorMessage = "Use letters only")]
        [Display(Name = "Caste Name (In English)")]
        public string CasteNameEng { get; set; } = null!;

        [StringLength(50)]
        [Display(Name = "जाति का नाम (हिंदी में)")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "जाति का नाम (हिंदी में) दर्ज करे")]
        [RegularExpression(@"^[\u0900-\u097F\s]+$", ErrorMessage = "जाति का नाम (हिंदी में) दर्ज करे")]
        public string CasteNameHin { get; set; } = null!;

        public bool IsActive { get; set; }

        public int CreatedBy { get; set; }

        public DateTime CreatedOn { get; set; }

        [StringLength(50)]
        [Unicode(false)]
        public string CreatedByIP { get; set; } = string.Empty;

        public int? LastUpdatedBy { get; set; }

        public DateTime? LastUpdatedOn { get; set; } = DateTime.UtcNow;

        [StringLength(50)]
        [Unicode(false)]
        public string LastUpdatedByIP { get; set; } = string.Empty;
    }
}
