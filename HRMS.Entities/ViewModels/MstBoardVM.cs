using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace HRMS.Entities.ViewModels
{
    public class MstBoardVM
    {
        [Key]
        public Int16 BoardId { get; set; }
       
        public string BoardNameEng { get; set; }
       
        public string BoardNameHin { get; set; }
       
        public string BoardCode { get; set; }
      
        public bool IsActive { get; set; }
    }
}
