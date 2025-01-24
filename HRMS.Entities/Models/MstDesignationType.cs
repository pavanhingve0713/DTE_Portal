using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace HRMS.Entities.Models
{
    public class MstDesignationType
    {
        [Key]
        public int DesignationTypeId { get; set; }
        [Display(Name = "Designation Type(In English)")]
        [Required(ErrorMessage = "Enter Designation Type")]
        [StringLength(50)]
        [Column(TypeName = "Varchar")]
        [RegularExpression(@"^[a-zA-Z\s\-.\(\)]+$", ErrorMessage = "Use letters only")]
        public string? DesignationTypeNameEng { get; set; }
        [Display(Name = "पदनाम प्रकार का नाम(हिंदी में)")]
        [Required(ErrorMessage = "कृपया पदनाम प्रकार का नाम(हिंदी में) दर्ज करें")]
        [RegularExpression(@"^[A-Za-z\u0900-\u097F\-\.\(\) ]+$", ErrorMessage = "Only () - . allow")]

        [StringLength(60)]
        [Column(TypeName = "nvarchar")]
        public string? DesignationTypeNameHin { get; set; }

        [Display(Name = "Designation Type Code")]
        [Required(ErrorMessage = "Enter Designation Type Code No.")]
        [StringLength(10)]
        [Column(TypeName = "Varchar")]
        [RegularExpression(@"^[0-9]{2}$", ErrorMessage = "Must be two digits numbers")]
        [MaxLength(2)]
        public string? DesignationTypeCode { get; set; }

        [DisplayName("Is Active")]
        public bool IsActive { get; set; } = true;
        public int CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        [StringLength(50)]
        [Column(TypeName = "varchar")]
        [Unicode(false)]
        public string CreatedByIP { get; set; } = string.Empty;
        public int? LastUpdatedBY { get; set; }
        public DateTime? LastUpdatedOn { get; set; }
        [StringLength(50)]
        [Column(TypeName = "varchar")]
        [Unicode(false)]
        public string? LastUpdatedByIP { get; set; } = string.Empty;
    }
}
