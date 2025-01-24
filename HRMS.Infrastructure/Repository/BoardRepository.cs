using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HRMS.Entities.Models;
using HRMS.Entities.ViewModels;
using HRMS.Infrastructure.Contract;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using TechnicalEducationPortal.Data;

namespace HRMS.Infrastructure.Repository
{
    public class BoardRepository : IBoardRepository
    {
        private readonly ApplicationDbContext _context;
        public BoardRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<MstBoardVM>> GetAllBoardAsync()
        {
            var result = await _context.MstBoards
               .Select(x => new MstBoardVM()
               {
                   BoardId = x.BoardId,
                   BoardNameEng = x.BoardNameEng,
                   BoardNameHin = x.BoardNameHin,
                   BoardCode = x.BoardCode,
                   IsActive = x.IsActive
               }).ToListAsync();
            return result;

        }
       
        public async Task<MstBoard> GetBoardByIdAsync(Int16 boardId)
        {
            return await _context.MstBoards.Where(x => x.BoardId == boardId).FirstOrDefaultAsync();
        }
        public async Task<bool> AddBoardAsync(MstBoard mstBoard)
        {
            var existName = await _context.MstBoards.FirstOrDefaultAsync(x => x.BoardCode == mstBoard.BoardCode);
            if (existName == null)
            {
                await _context.MstBoards.AddAsync(mstBoard);     
                return true;
            }
            return false;
        }
        public async Task<bool> UpdateBoardAsync(MstBoard mstBoard)
        {
            var existName = await _context.MstBoards.FirstOrDefaultAsync(x => x.BoardCode == mstBoard.BoardCode && x.BoardId != mstBoard.BoardId);

            if (existName == null)
            {
                _context.MstBoards.Update(mstBoard);
                return true;
            }
            else
            {
                return false;
            }
           
        }
       

    }
}
