using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using HRMS.Entities.Models;
using HRMS.Infrastructure.Contract;

namespace HRMS.Business.Masters
{
    public class CasteBAL
    {
        private readonly IUnitOfWork _unitOfWork;
        public CasteBAL(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<IEnumerable<MstCaste>> GetAllCasteAsync()
        {
            return await _unitOfWork.casteRepository.GetAllCasteAsync();
        }
        public async Task AddCasteAsync(MstCaste mstCaste)
        {
             await _unitOfWork.casteRepository.AddCasteAsync(mstCaste);
        }
        public async Task<MstCaste> GetCasteByIdAsync(int id)
        {
            return await _unitOfWork.casteRepository.GetCasteByIdAsync(id);
        }
        public async Task UpdateCasteAsync(MstCaste mstCaste)
        {
             await _unitOfWork.casteRepository.UpdateCasteAsync(mstCaste);
             await _unitOfWork.CommitTransactionAsync();

        }

    }
}
