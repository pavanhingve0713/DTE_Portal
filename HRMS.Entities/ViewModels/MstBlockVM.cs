using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace HRMS.Entities.ViewModels
{
    public class MstBlockVM
    {
        [Key]
        public int BlockId { get; set; }
       
        public string StateNameEng { get; set; }
       
        public string DivisionNameEng { get; set; }
      
        public string DistrictNameEng { get; set; }
       
        public string BlockNameEng { get; set; }
       
        public string BlockNameHin { get; set; }
        
        public string BlockCode { get; set; }
      
        public bool IsActive { get; set; }
    }
}
