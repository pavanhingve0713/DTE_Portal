using HRMS.Entities.Models;
using HRMS.Entities.ViewModels;
using HRMS.Infrastructure.Contract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechnicalEducationPortal.Data;

namespace HRMS.Infrastructure.Repository
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly ApplicationDbContext _context;
        public EmployeeRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<EmployeeInfoVM>> GetAllEmployeeAsync()
        {
			var result = await _context.EmployeeInfos
			   .Select(x => new EmployeeInfoVM()
			   {
				   EmpId = x.EmpId,
				   FirstName = x.FirstName,
				   LastName = x.LastName,
				   MobileNo = x.MobileNo,
				   Address = x.Address
			   }).ToListAsync();
			return result;
		}
        public async Task AddEmployeeAsync(EmployeeInfo employeeInfo)
        {
            await _context.EmployeeInfos.AddAsync(employeeInfo);
        }
        public async Task<EmployeeInfo> GetEmployeeByIdAsync(int id)
        {
            return await _context.EmployeeInfos.FindAsync(id);
        }
		public void UpdateEmployee(EmployeeInfo employeeInfo)
		{
			_context.EmployeeInfos.Update(employeeInfo);
		}


	}
}
