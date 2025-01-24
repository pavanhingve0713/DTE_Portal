using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HRMS.Entities.Models;
using HRMS.Entities.ViewModels;
using HRMS.Infrastructure.Contract;
using Microsoft.EntityFrameworkCore;
using TechnicalEducationPortal.Data;

namespace HRMS.Infrastructure.Repository
{
    public class DivisionRepository : IDivisionRepository
    {
        private readonly ApplicationDbContext _context;

        public DivisionRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        // Method to get all divisions with state names using join
        public async Task<IEnumerable<MstDivisionVM>> GetAllDivisionAsync()
        {
            var result = await (from division in _context.MstDivisions
                                join state in _context.MstStates
                                on division.StateId equals state.StateId
                                select new MstDivisionVM
                                {
                                    DivisionId = division.DivisionId,
                                    DivisionNameEng = division.DivisionNameEng,
                                    DivisionNameHin = division.DivisionNameHin,
                                    DivisionCode = division.DivisionCode,
                                    IsActive = division.IsActive,
                                    StateId = state.StateId,
                                    StateNameEng = state.StateNameEng // Assuming StateNameEng exists in MstState
                                }).ToListAsync();

            return result;
        }

        public async Task<MstDivision> GetDivisionByIdAsync(int id)
        {
            return await _context.MstDivisions.FindAsync(id);
        }

        public async Task InsertDivisionAsync(MstDivision mstDivision)
        {
            if (string.IsNullOrEmpty(mstDivision.DivisionNameEng))
            {
                throw new ArgumentException("Division name cannot be empty");
            }

            await _context.MstDivisions.AddAsync(mstDivision);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<MstState>> GetAllStatesAsync()
        {
            return await _context.MstStates.Where(x => x.IsActive == true).OrderBy(y => Convert.ToInt32(y.StateCode)).ToListAsync().ConfigureAwait(false);
        }

        public async Task UpdateState(MstDivision mstDivision)
        {
            var existingDivision = await _context.MstDivisions.FindAsync(mstDivision.DivisionId);
            if (existingDivision == null)
            {
                throw new KeyNotFoundException("Division not found.");
            }

            // Update only the modified fields
            existingDivision.DivisionNameEng = mstDivision.DivisionNameEng ?? existingDivision.DivisionNameEng;
            existingDivision.DivisionNameHin = mstDivision.DivisionNameHin ?? existingDivision.DivisionNameHin;
            existingDivision.DivisionCode = mstDivision.DivisionCode ?? existingDivision.DivisionCode;
            existingDivision.IsActive = mstDivision.IsActive;
            existingDivision.StateId = mstDivision.StateId;

            _context.MstDivisions.Update(existingDivision);
            await _context.SaveChangesAsync();
        }

        private bool _disposed = false;
        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
                _disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }

}
