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
    public class ReligionsRepository : IReligionsRepository
    {
        private readonly ApplicationDbContext _context;
        public ReligionsRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<MstReligion>> GetAllReligionsAsync()
        {
            return await _context.MstReligions.ToListAsync();
        }
        public async Task<MstReligion> GetReligionByIdAsync(int id)
        {
            return await _context.MstReligions.FindAsync(id);
        }
        public async Task AddReligionAsync(MstReligion mstReligion)
        {
             await _context.MstReligions.AddAsync(mstReligion);
             await _context.SaveChangesAsync();

        }
        public async Task UpdateReligionAsync(MstReligion mstReligion)
        {
             _context.MstReligions.Update(mstReligion);
            await _context.SaveChangesAsync();
        }
    }
}
