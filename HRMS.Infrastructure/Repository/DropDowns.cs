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
    public class DropDowns : IDropDowns
    {
        private readonly ApplicationDbContext _context;
        public DropDowns(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<List<MstState>> FillStatesAsync()
        {
            return await _context.MstStates.ToListAsync();
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
       
    }
}
