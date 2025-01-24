using HRMS.Entities.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRMS.Entities.ViewModels
{
    public class EmployeeInfoVM
    {
        [Key]
        public int EmpId { get; set; }
        [Required(ErrorMessage ="Field is Required")]
        [DisplayName("First Name")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Field is Required")]
        [DisplayName("Last Name")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "Field is Required")]
        [DisplayName("Mobile Number")]
        public string MobileNo { get; set; }
        [Required(ErrorMessage = "Field is Required")]
        [DisplayName("Address")]
        public string Address { get; set; }

        public ICollection<EmployeeInfo> Employees { get; set; }
    }
}
