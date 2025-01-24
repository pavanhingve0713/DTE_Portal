using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace HRMS.Entities.Models
{
    public class MstParliamentary
    {
        [Key]
        public int ParliamentaryId { get; set; }
        [Required]
        [StringLength(80)]
        [Unicode(false)]
        public string ParliamentaryNameEng { get; set; }
        [Required]
        [StringLength(90)]
        public string ParliamentaryNameHin { get; set; }
        [Required]
        [StringLength(2)]
        [Unicode(false)]
        public string ParliamentaryCode { get; set; }
        [Required]
        public bool IsActive { get; set; }

       public bool IsDelete { get; set; } = true;  

    }
}
