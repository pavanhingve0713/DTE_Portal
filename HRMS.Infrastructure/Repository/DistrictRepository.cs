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
    public class DistrictRepository : IDistrictRepository
    {
        private readonly ApplicationDbContext _context;
        public DistrictRepository(ApplicationDbContext context)
        {
            _context = context;
        }
       
        public async Task<IEnumerable<MstDistrictVM>> GetAllDistrictAsync()
        {
            var districts = await (from district in _context.MstDistricts
                                   join state in _context.MstStates on district.StateId equals state.StateId
                                   join division in _context.MstDivisions on district.DivisionId equals division.DivisionId
                                   select new MstDistrictVM
                                   {
                                       DistrictId = district.DistrictId,                                     
                                       StateNameEng = state.StateNameEng,    // Get State Name
                                       DivisionNameEng = division.DivisionNameEng, 
                                       DistrictNameEng = district.DistrictNameEng,
                                       DistrictNameHin = district.DistrictNameHin,
                                       DistrictCode = district.DistrictCode,
                                       IsActive = district.IsActive
                                   }).ToListAsync();

            return districts;
        }


        public async Task<bool> AddDistrictAsync(MstDistrict mstDistrict)
        {
            var existName = await _context.MstDistricts.Where(x => x.DistrictCode == mstDistrict.DistrictCode).FirstOrDefaultAsync();

            if (existName == null)
            {
                await _context.MstDistricts.AddAsync(mstDistrict);
                await _context.SaveChangesAsync();
                return true;
            }
            else
            { 
                return false;
            }
        }
        public async Task<MstDistrict> EditDistrictAsync(int districtId)
        {
            return await _context.MstDistricts.Where(x => x.DistrictId == districtId).FirstOrDefaultAsync();
        }
        public async Task<bool> UpdateDistrictAsync(MstDistrict mstDistrict)
        {
            // Check if the district with the same DistrictCode already exists, but has a different DistrictId
            var existName = await _context.MstDistricts
                .Where(x => x.DistrictCode == mstDistrict.DistrictCode && x.DistrictId != mstDistrict.DistrictId)
                .FirstOrDefaultAsync();

            // If no duplicate DistrictCode exists, update the district
            if (existName == null)
            {
                _context.MstDistricts.Update(mstDistrict);
                await _context.SaveChangesAsync();
                return true; // Successful update
            }
            else
            {
                return false; // DistrictCode is already in use
            }
        }

        public async Task<IEnumerable<MstDivision>> GetDivisionsByStateIdAsync(int stateId)
        {
            // Assuming _context is your DbContext
            return await _context.MstDivisions.Where(d => d.StateId == stateId).Select(d => new MstDivision
                {
                    DivisionId = d.DivisionId,
                    DivisionNameEng = d.DivisionNameEng,
                    DivisionCode = d.DivisionCode
                })
                .ToListAsync();
        }
        public async Task<List<MstState>> FillStatesAsync()
        {
            return await _context.MstStates.ToListAsync();
        }
    }
}
