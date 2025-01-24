using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HRMS.Entities.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace HRMS.Entities.Models
{
    public partial class MstBlock
    {
        [Key]
        public int BlockId { get; set; }
        [DisplayName("State")]
        [Required(ErrorMessage = "Select State")]
        public Int16 StateId { get; set; }
        [DisplayName("Division")]
        [Required(ErrorMessage = "Select Division")]
        public int DivisionId { get; set; }
        [DisplayName("District")]
        [Required(ErrorMessage = "Select District")]
        public int DistrictId { get; set; }       
        [DisplayName("Block Name(In English)")]
        [RegularExpression(@"^[a-zA-Z\s-]+$", ErrorMessage = "Use letters only")]
        [Required(ErrorMessage = "Enter Block Name.")]
        [StringLength(50)]
        [Column(TypeName = "varchar")]
        [Unicode(false)]
        public string BlockNameEng { get; set; }
        [DisplayName("ब्लॉक का नाम(हिंदी में)")]
        [Required(ErrorMessage = "कृपया ब्लॉक का नाम दर्ज करें")]
        [RegularExpression(@"^[\u0900-\u097F\s]+$", ErrorMessage = "केवल हिंदी अक्षरों की अनुमति है")]       
        [Column(TypeName = "nvarchar")]
        [StringLength(60)]
        public string BlockNameHin { get; set; }
        [DisplayName("Block Code No.")]
        [Required(ErrorMessage = "Enter Code No.")]
        [RegularExpression(@"^[0-9]{1,3}$", ErrorMessage = "Must be 3 digits numbers")]
        [StringLength(10)]
        [Column(TypeName = "varchar")]
        public string BlockCode { get; set; }
        [DisplayName("Is Active")]
        public bool IsActive { get; set; } = true;
        public int CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        [StringLength(50)]
        [Column(TypeName = "Varchar")]
        [Unicode(false)]
        public string IpAddress { get; set; }
        public int? LastUpdatedBy { get; set; }
        public DateTime? LastUpdatedOn { get; set; }

       
    }
}
