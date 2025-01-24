using HRMS.Entities.Models;
using HRMS.Entities.ViewModels;
using HRMS.Infrastructure.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRMS.Business.Masters
{
    public class EmployeeBAL
    {
        private readonly IUnitOfWork _unitOfWork;
        public EmployeeBAL(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<IEnumerable<EmployeeInfoVM>> GetAllEmployeeAsync()
        {
            return await _unitOfWork.employeeRepository.GetAllEmployeeAsync();
        }

		public async Task AddEmployeeAsync(EmployeeInfo employeeInfo)
        {
            await _unitOfWork.employeeRepository.AddEmployeeAsync(employeeInfo);
            await _unitOfWork.CommitTransactionAsync();
        }
        public async Task<EmployeeInfo> GetEmployeeByIdAsync(int id)
        {
            return await _unitOfWork.employeeRepository.GetEmployeeByIdAsync(id);
        }
        public async Task UpdateEmployeeAsync(EmployeeInfo employeeInfo)
        {
            _unitOfWork.employeeRepository.UpdateEmployee(employeeInfo);
            await _unitOfWork.CommitTransactionAsync();
        }
    }
}
