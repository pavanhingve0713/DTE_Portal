using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRMS.Entities.Models
{
    public class EmployeeInfo
    {
		[Key]
		public int EmpId { get; set; }
		[StringLength(20)]
		[DisplayName("First Name")]
		[Required(ErrorMessage = "Field is Required")]
		public string FirstName { get; set; }
		[StringLength(20)]
		[DisplayName("Last Name")]
		[Required(ErrorMessage = "Field is Required")]
		public string LastName { get; set; }
		[StringLength(15)]
		[Unicode(false)]
		[Required(ErrorMessage = "Field is Required")]
		[DisplayName("Mobile Number")]
		public string MobileNo { get; set; }
		[StringLength(100)]
		[Required(ErrorMessage = "Field is Required")]
		[DisplayName("Address")]
		public string Address { get; set; }
	}
}
