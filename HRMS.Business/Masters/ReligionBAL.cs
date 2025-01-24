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
    public class ReligionBAL
    {
        private readonly IUnitOfWork _unitOfWork;
        public ReligionBAL(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        //public async Task<IEnumerable<MstReligion>> GetAllReligionsAsync()
        //{
        //    return await _unitOfWork.religionsRepository.GetAllReligionsAsync();
        //}
        public async Task<IEnumerable<MstReligionVM>> GetAllReligionsAsync()
        {
            var religion = await _unitOfWork.religionsRepository.GetAllReligionsAsync();
            return religion.Select(r => new MstReligionVM
            {
                ReligionId = r.ReligionId,
                ReligionNameEng = r.ReligionNameEng,
                ReligionNameHin = r.ReligionNameHin,
                IsActive = r.IsActive
            }).ToList();

        }
        public async Task<MstReligion> GetReligionByIdAsync(int id)
        {
            return await _unitOfWork.religionsRepository.GetReligionByIdAsync(id);
        }
        public async Task AddReligionAsync(MstReligion mstReligion)
        {
             await _unitOfWork.religionsRepository.AddReligionAsync(mstReligion);
        }
        public async Task UpdateReligionAsync(MstReligion mstReligion)
        {
             await _unitOfWork.religionsRepository.UpdateReligionAsync(mstReligion);
        }
    }
}
