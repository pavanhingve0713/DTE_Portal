using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HRMS.Entities.Models;
using HRMS.Infrastructure.Contract;

namespace HRMS.Business.Masters
{
    public class ParliamentryBAL
    {
        private readonly IUnitOfWork _unitOfWork;
        public ParliamentryBAL(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<IEnumerable<MstParliamentary>> GetAllParliamentaryAsync()
        {
            return await _unitOfWork.parliamentaryRepository.GetAllParliamentaryAsync();
        }
        public async Task<MstParliamentary> GetParliamentaryByIdAsync(int id)
        {
            return await _unitOfWork.parliamentaryRepository.GetParliamentaryByIdAsync(id);
        }
        public async Task<bool> AddParliamentaryAsync(MstParliamentary mstParliamentary)
        {
            var result = await _unitOfWork.parliamentaryRepository.AddParliamentaryAsync(mstParliamentary);
            await _unitOfWork.CommitTransactionAsync();
            return result;
        }
        public async Task<bool> UpdateParliamentaryAsync(MstParliamentary mstParliamentary)
        {
            var result = await _unitOfWork.parliamentaryRepository.UpdateParliamentaryAsync(mstParliamentary);
            await _unitOfWork.CommitTransactionAsync();
            return result;
        }
        public async Task DeleteParliamentaryAsync(int id)
        {
            await _unitOfWork.parliamentaryRepository.DeleteParliamentaryAsync(id);
            await _unitOfWork.CommitTransactionAsync();
        }
    }
}
