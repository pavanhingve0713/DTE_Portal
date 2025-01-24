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
    public class MstDistrictBAL
    {
        private readonly IUnitOfWork _unitOfWork;
        public MstDistrictBAL(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<IEnumerable<MstDistrictVM>> GetAllDistrictAsync()
        {
            return await _unitOfWork.districtRepository.GetAllDistrictAsync();
        }
        public async Task<bool> AddDistrictAsync(MstDistrict mstDistrict)
        {
            var result = await _unitOfWork.districtRepository.AddDistrictAsync(mstDistrict);
            await _unitOfWork.CommitTransactionAsync();
            return result;
        }
        public async Task<MstDistrict> EditDistrictAsync(int districtId)
        {
            return await _unitOfWork.districtRepository.EditDistrictAsync(districtId);
        }
        public async Task<bool> UpdateDistrictAsync(MstDistrict mstDistrict)
        {
            var result = await _unitOfWork.districtRepository.UpdateDistrictAsync(mstDistrict);
            await _unitOfWork.CommitTransactionAsync();
            return result;
        }
        public async Task<IEnumerable<MstDivision>> GetDivisionsByStateIdAsync(int stateId)
        {
            return await _unitOfWork.districtRepository.GetDivisionsByStateIdAsync(stateId);
        }
        public async Task<List<MstState>> FillStatesAsync()
        {
            return await _unitOfWork.districtRepository.FillStatesAsync();
        }
    }
}
