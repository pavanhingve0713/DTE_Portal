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
    public class ParliamentaryRepository : IParliamentaryRepository
    {
        private readonly ApplicationDbContext _context;
        public ParliamentaryRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<MstParliamentary>> GetAllParliamentaryAsync()
        {
            return await _context.MstParliamentaries.Where(x => x.IsDelete).ToListAsync();
        }
        public async Task<MstParliamentary> GetParliamentaryByIdAsync(int id)
        {
            return await _context.MstParliamentaries.FirstOrDefaultAsync(x => x.ParliamentaryId == id && x.IsDelete);
        }
        public async Task<bool> AddParliamentaryAsync(MstParliamentary mstParliamentary)
        {
            var existName = _context.MstParliamentaries.Where(x => x.ParliamentaryCode == mstParliamentary.ParliamentaryCode).FirstOrDefaultAsync();
            if (existName == null)
            {
                await _context.MstParliamentaries.AddAsync(mstParliamentary);
                return true;
            }
            else
            {
                return false;
            }
        }
        public async Task<bool> UpdateParliamentaryAsync(MstParliamentary mstParliamentary)
        {

            var existName = await _context.MstParliamentaries.Where(x => x.ParliamentaryCode == mstParliamentary.ParliamentaryCode && x.ParliamentaryId != mstParliamentary.ParliamentaryId).FirstOrDefaultAsync();
            if (existName == null)
            {
                 _context.MstParliamentaries.Update(mstParliamentary);
                return true;
            }
            else
            {
                return false;
            }
        }
        public async Task DeleteParliamentaryAsync(int id)
        {
            var entity = await GetParliamentaryByIdAsync(id);
            if (entity != null)
            {
                entity.IsDelete = false;
                _context.MstParliamentaries.Update(entity);
            }
        }

    }
}
