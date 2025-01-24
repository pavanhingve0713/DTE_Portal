using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HRMS.Entities.Models;
using HRMS.Entities.ViewModels;
using HRMS.Infrastructure.Contract;
using Microsoft.EntityFrameworkCore;
using TechnicalEducationPortal.Data;

namespace HRMS.Infrastructure.Repository
{
    public class DesignationTypeRepository : IDesignationTypeRepository
    {
        private readonly ApplicationDbContext _context;
        public DesignationTypeRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<MstDesignationTypeVM>> GetAllDesignationTypeAsync()
        {
            var result = await _context.MstDesignationTypes
                .Select(x => new MstDesignationTypeVM()
                {
                    DesignationTypeId = x.DesignationTypeId,
                    DesignationTypeNameEng = x.DesignationTypeNameEng,
                    DesignationTypeNameHin = x.DesignationTypeNameHin,
                    DesignationTypeCode = x.DesignationTypeCode,
                    IsActive = x.IsActive
                }).ToListAsync(); 
            return result;
        }
        public async Task<bool> AddDesignationTypeAsync(MstDesignationType mstDesignationType)
        {
            var existName = _context.MstDesignationTypes.Where(x => x.DesignationTypeCode == mstDesignationType.DesignationTypeCode).FirstOrDefault();
            if (existName == null)
            {
                await _context.MstDesignationTypes.AddAsync(mstDesignationType);
                return true;
            }
            else
            {
                return false;
            }
        }
        public async Task<MstDesignationType> GetDesignationTypeByIdAsync(int designationTypeId)
        {
            return await _context.MstDesignationTypes.Where(x => x.DesignationTypeId == designationTypeId).FirstOrDefaultAsync();
        }
        public async Task<bool> UpdateDesignationTypeAsync(MstDesignationType mstDesignationType)
        {
            // Check if a DesignationTypeCode already exists for another record
            var existName = await _context.MstDesignationTypes
                                          .FirstOrDefaultAsync(x => x.DesignationTypeCode == mstDesignationType.DesignationTypeCode
                                                                 && x.DesignationTypeId != mstDesignationType.DesignationTypeId);

            if (existName == null)
            {
                // Update the record and save changes
                _context.MstDesignationTypes.Update(mstDesignationType);
                return true;
            }
            else
            {
                // Duplicate found, do not update
                return false;
            }
        }



    }
}
