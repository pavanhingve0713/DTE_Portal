using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HRMS.Entities.Models;
using HRMS.Entities.ViewModels;
using HRMS.Infrastructure.Contract;
using HRMS.Infrastructure.Repository;

namespace HRMS.Business.Masters
{
    public class MstDivisionBAL
    {
        private readonly IUnitOfWork _unitOfWork;
        public MstDivisionBAL(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<IEnumerable<MstDivisionVM>> GetAllDivisionAsync()
        {
            return await _unitOfWork.divisionRepository.GetAllDivisionAsync();
        }

        //public async Task<MstDivision> GetDivisionByIdAsync(int id)
        //{
        //    return await _unitOfWork.divisionRepository.GetDivisionByIdAsync(id);
        //}
        public async Task<(MstDivision, string)> GetDivisionByIdAsync(int id)
        {
            try
            {
                var division = await _unitOfWork.divisionRepository.GetDivisionByIdAsync(id);
                if (division == null)
                {
                    return (null, "Division not found.");
                }
                return (division, null);
            }
            catch (Exception ex)
            {
                return (null, "Error fetching division: " + ex.Message);
            }
        }

        //public async Task InsertDivisionAsync(MstDivision mstDivision)
        //{
        //    await _unitOfWork.divisionRepository.InsertDivisionAsync(mstDivision);
        //}
        public async Task<(string, bool)> InsertDivisionAsync(MstDivision mstDivision)
        {
            // Get all divisions to check if code or name already exists
            var allDivisions = await _unitOfWork.divisionRepository.GetAllDivisionAsync();

            if (allDivisions.Any(d => d.DivisionCode == mstDivision.DivisionCode))
                return ($"Code No.: {mstDivision.DivisionCode} already exists.", false);

            if (allDivisions.Any(d => d.DivisionNameEng == mstDivision.DivisionNameEng))
                return ($"Division Name (In English): {mstDivision.DivisionNameEng} already exists.", false);

            // Insert new division
            await _unitOfWork.divisionRepository.InsertDivisionAsync(mstDivision);
            await _unitOfWork.CommitTransactionAsync(); // Commit transaction

            return ("Division inserted successfully.", true);
        }

        public async Task<IEnumerable<MstState>> GetAllStatesAsync()
        {
            return await _unitOfWork.divisionRepository.GetAllStatesAsync();
        }
        public async Task<(string, bool)> UpdateDivisionAsync(MstDivision mstDivision)
        {
            // Get all divisions
            var allDivisions = await _unitOfWork.divisionRepository.GetAllDivisionAsync();

            // Check if the Division Code already exists (excluding current division)
            if (allDivisions.Any(d => d.DivisionCode == mstDivision.DivisionCode && d.DivisionId != mstDivision.DivisionId))
                return ($"Code No.: {mstDivision.DivisionCode} already exists.", false);

            // Check if the Division Name (in English) already exists (excluding current division)
            if (allDivisions.Any(d => d.DivisionNameEng == mstDivision.DivisionNameEng && d.DivisionId != mstDivision.DivisionId))
                return ($"Division Name (In English): {mstDivision.DivisionNameEng} already exists.", false);

            // Update division in the repository
            await _unitOfWork.divisionRepository.UpdateState(mstDivision);
            await _unitOfWork.CommitTransactionAsync(); // Commit transaction

            return ("Division updated successfully.", true);
        }
    }
}
