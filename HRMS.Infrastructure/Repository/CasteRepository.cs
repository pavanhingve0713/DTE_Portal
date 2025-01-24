using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HRMS.Entities.Models;
using HRMS.Infrastructure.Contract;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TechnicalEducationPortal.Data;

namespace HRMS.Infrastructure.Repository
{
    public class CasteRepository : ICasteRepository
    {
        private readonly ApplicationDbContext _context;
        public CasteRepository(ApplicationDbContext context)
        {
            _context = context;
        }   
        public async Task<IEnumerable<MstCaste>> GetAllCasteAsync()
        {
            return await _context.MstCastes.ToListAsync();
        }
        public async Task AddCasteAsync(MstCaste mstCaste)
        {
            await _context.MstCastes.AddAsync(mstCaste);
            await _context.SaveChangesAsync();
        }
        public async Task<MstCaste> GetCasteByIdAsync(int id)
        {
            return await _context.MstCastes.FindAsync(id);
        }
        public async Task UpdateCasteAsync(MstCaste mstCaste)
        {
             _context.MstCastes.Update(mstCaste);
            await _context.SaveChangesAsync();
        }
    }
}
