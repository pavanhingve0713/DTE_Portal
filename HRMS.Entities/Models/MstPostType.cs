using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace HRMS.Entities.Models
{
    public class MstPostType
    {
        [Key]
        public Int16 TypeOfPostId { get; set; }

        [StringLength(50)]
        [Unicode(false)]
        [Required(ErrorMessage = "Field is required.")]
        [RegularExpression(@"^[a-zA-Z\s]+$", ErrorMessage = "Use characters only.")]
        [Display(Name = "Post Name (In English)")]
        public string PostNameEng { get; set; } = null!;

        [StringLength(60)]
        [Display(Name = "पद का नाम (हिंदी में)")]
        [RegularExpression(@"^[\u0900-\u097F\s]+$", ErrorMessage = "कृपया पद का नाम हिंदी में दर्ज करे।")]
        [Required(ErrorMessage = "कृपया पद का नाम दर्ज करे।")]
        public string PostNameHin { get; set; } = null!;

        [StringLength(2)]
        [Unicode(false)]
        [Required(ErrorMessage = "Field is required.")]
        [RegularExpression(@"^[0-9]+$", ErrorMessage = "Use numeric value only.")]
        [Display(Name = "Post Code No.")]
        public string PostCode { get; set; } = null!;

        public bool IsActive { get; set; } = true;

        public int CreatedBy { get; set; }
      
        public DateTime CreatedOn { get; set; }


        [StringLength(50)]
        [Unicode(false)]
        public string IPAddress { get; set; }

        public int? LastUpdatedBy { get; set; }

        public DateTime? LastUpdatedOn { get; set; }
    }
}
