using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HRMS.Entities.Models;
using HRMS.Infrastructure.Contract;
using Microsoft.EntityFrameworkCore;
using TechnicalEducationPortal.Data;

namespace HRMS.Infrastructure.Repository
{
    public class BloodGroupRepository : IBloodGroupRepository
    {
        private readonly ApplicationDbContext _context;
        public BloodGroupRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<MstBloodGroup>> GetAllBloodGroupAsync()
        {
            return await _context.MstBloodGroups.ToListAsync();
        }
        public async Task<bool> AddBloodGroupAsync(MstBloodGroup mstBloodGroup)
        {
            var existName = await _context.MstBloodGroups.Where(x => x.BloodGroupName == mstBloodGroup.BloodGroupName && x.BloodGroupId != mstBloodGroup.BloodGroupId).FirstOrDefaultAsync();
            if (existName == null)
            {
                await _context.MstBloodGroups.AddAsync(mstBloodGroup);
                return true;
            }
            else
            {
                return false;
            }            
        }
        public async Task<MstBloodGroup> GetBloodGroupByIdAsync(int id)
        {
            return await _context.MstBloodGroups.FindAsync(id);
        }
        public async Task<bool> UpdateBloodGroupAsync(MstBloodGroup mstBloodGroup)
        {
            var existName = await _context.MstBloodGroups.Where(x => x.BloodGroupName == mstBloodGroup.BloodGroupName && x.BloodGroupId != mstBloodGroup.BloodGroupId).FirstOrDefaultAsync();
            if (existName == null)
            {
                 _context.MstBloodGroups.Update(mstBloodGroup);
                return true;
            }
            else
            {
                return false;
            }
        }
        
    }
}
