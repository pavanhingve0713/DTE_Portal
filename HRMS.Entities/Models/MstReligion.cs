using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace HRMS.Entities.Models
{
    public class MstReligion
    {
        [Key]
        public int ReligionId { get; set; }
        [Unicode(false)]
        [StringLength(20)]
        [Required(ErrorMessage ="Field is Required")]
        [RegularExpression(@"^[a-zA-Z\s]+$", ErrorMessage = "Use characters only.")]
        [DisplayName("Religion Name(In English)")]
        public string ReligionNameEng { get; set; }
        [RegularExpression(@"^[\u0900-\u097F\s]+$", ErrorMessage = "Religion Name(In Hindi)")]
        [StringLength(40)]
        [DisplayName("Religion Name(In Hindi)")]
        [Required(ErrorMessage = "Field is Required")]
        public string ReligionNameHin { get; set; }
        [DisplayName("IsActive")]
        public bool IsActive { get; set; }
    }
}
