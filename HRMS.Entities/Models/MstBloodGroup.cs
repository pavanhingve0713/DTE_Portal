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
    public class MstBloodGroup
    {
        [Key]
        public int BloodGroupId { get; set; }
        [Required(ErrorMessage ="Field id Required.")]
        [Unicode(false)]
        [RegularExpression(@"^(A|B|AB|O)[+-]$", ErrorMessage = "Please enter a valid blood group")]

        [Display(Name = "Blood Group")]
        public string BloodGroupName { get; set; }
        [DisplayName("IsActive")]
        public bool IsActive { get; set; }



    }
}
