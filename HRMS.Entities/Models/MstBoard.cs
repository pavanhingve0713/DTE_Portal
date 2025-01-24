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
    public class MstBoard
    {
        [Key]
        public Int16 BoardId { get; set; }
        [Required(ErrorMessage = "Field is required.")]
        [MaxLength(60)]
        [RegularExpression(@"^[a-zA-Z\s.]*$", ErrorMessage = "Use Characters only")]
        [DisplayName("Board Name(In English)")]
        public string BoardNameEng { get; set; }
        [Required(ErrorMessage = "कृपया बोर्ड का नाम दर्ज करें.")]
        [StringLength(90)]
        [DisplayName("बोर्ड का नाम (हिंदी में)")]
        [RegularExpression(@"^[\x41-\x5A\x30-\x39\x61-\x7A\x2C-\x2E\u0900-\u097F\s]*$", ErrorMessage = "Use alphanumeric, hindi  & some special symbols like (-)Hyphen, (,)Comma, (.)Dot characters only.")]
        public string BoardNameHin { get; set; }
        [Required(ErrorMessage = "Field is required.")]
        [StringLength(5)]
        [Unicode(false)]
        [RegularExpression(@"^[0-9]{1,2}$", ErrorMessage = "Must be 1 to 2 digits numbers.")]
        [DisplayName("Board Code No.")]
        public string BoardCode { get; set; }
        [DisplayName("IsActive")]
        public bool IsActive { get; set; }
    }
}
