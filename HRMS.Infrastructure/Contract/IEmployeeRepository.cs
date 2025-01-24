using HRMS.Entities.Models;
using HRMS.Entities.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRMS.Infrastructure.Contract
{
    public interface IEmployeeRepository
    {
        Task<IEnumerable<EmployeeInfoVM>> GetAllEmployeeAsync();
        void UpdateEmployee(EmployeeInfo employeeInfo);
		Task AddEmployeeAsync(EmployeeInfo employeeInfo);
        Task<EmployeeInfo> GetEmployeeByIdAsync(int id);

	}
}
