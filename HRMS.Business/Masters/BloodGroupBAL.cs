using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HRMS.Entities.Models;
using HRMS.Infrastructure.Contract;

namespace HRMS.Business.Masters
{
    public class BloodGroupBAL
    {
        private readonly IUnitOfWork _unitOfWork;
        public BloodGroupBAL(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<IEnumerable<MstBloodGroup>> GetAllBloodGroupAsync()
        {
            return await _unitOfWork.bloodGroupRepository.GetAllBloodGroupAsync();
        }
        public async Task<bool> AddBloodGroupAsync(MstBloodGroup mstBloodGroup)
        {
           var result = await _unitOfWork.bloodGroupRepository.AddBloodGroupAsync(mstBloodGroup);
            await _unitOfWork.CommitTransactionAsync();
            return result;
        }
        public async Task<MstBloodGroup> GetBloodGroupByIdAsync(int id)
        {
            return await _unitOfWork.bloodGroupRepository.GetBloodGroupByIdAsync(id);
        }
        public async Task<bool> UpdateBloodGroupAsync(MstBloodGroup mstBloodGroup)
        {
           var result = await _unitOfWork.bloodGroupRepository.UpdateBloodGroupAsync(mstBloodGroup);
            await _unitOfWork.CommitTransactionAsync();
            return result;
        }
    }
}
