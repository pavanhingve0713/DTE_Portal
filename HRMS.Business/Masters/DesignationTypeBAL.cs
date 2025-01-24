using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HRMS.Entities.Models;
using HRMS.Entities.ViewModels;
using HRMS.Infrastructure.Contract;

namespace HRMS.Business.Masters
{
    public class DesignationTypeBAL
    {
        private readonly IUnitOfWork _unitOfWork;
        public DesignationTypeBAL(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<IEnumerable<MstDesignationTypeVM>> GetAllDesignationTypeAsync()
        {
            return await _unitOfWork.designationTypeRepository.GetAllDesignationTypeAsync();
        }
        public async Task<bool> AddDesignationTypeAsync(MstDesignationType mstDesignationType)
        {
           var result = await _unitOfWork.designationTypeRepository.AddDesignationTypeAsync(mstDesignationType);
            await _unitOfWork.CommitTransactionAsync();
            return result;
        }
        public async Task<MstDesignationType> GetDesignationTypeByIdAsync(int designationTypeId)
        {
            var result = await _unitOfWork.designationTypeRepository.GetDesignationTypeByIdAsync(designationTypeId);
            return result;

        }
        public async Task<bool> UpdateDesignationTypeAsync(MstDesignationType mstDesignationType)
        {
            var result = await _unitOfWork.designationTypeRepository.UpdateDesignationTypeAsync(mstDesignationType);
            await _unitOfWork.CommitTransactionAsync();
            return result;

        }

    }
}










