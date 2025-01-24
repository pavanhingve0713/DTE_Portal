using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace HRMS.Entities.ViewModels
{
    public class MstReligionVM
    {
        public int ReligionId { get; set; }

        [StringLength(20)]
        [Unicode(false)]
        public string ReligionNameEng { get; set; }

        [StringLength(40)]
        public string ReligionNameHin { get; set; }

        public bool IsActive { get; set; }
    }
}
