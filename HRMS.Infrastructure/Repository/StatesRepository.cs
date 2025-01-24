


using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HRMS.Infrastructure.Contract;
using TechnicalEducationPortal.Data;
using HRMS.Entities.Models;

namespace HRMS.Infrastructure.Repository
{
    public class StatesRepository : IStatesRepository
    {
        private readonly ApplicationDbContext _context;
        public StatesRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<MstState>> GetAllStateAsync()
        {
            return await _context.MstStates.ToListAsync();
        }
        public async Task<MstState> GetStateByIdAsync(Int16 id)
        {
            return await _context.MstStates.FindAsync(id);
        }
        public async Task InsertStateAsync(MstState mstState)
        {

            await _context.MstStates.AddAsync(mstState);

        }
        public async Task UpdateState(MstState mstState)
        {
            var state = await _context.MstStates.FindAsync(mstState.StateId);
            if (state != null)
            {
                state.StateNameEng = mstState.StateNameEng;
                state.StateNameHin = mstState.StateNameHin;
                state.StateCode = mstState.StateCode;
                state.IsActive = mstState.IsActive;

                _context.MstStates.Update(state);
            }
        }
        private bool disposed = false;
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            this.disposed = true;
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
