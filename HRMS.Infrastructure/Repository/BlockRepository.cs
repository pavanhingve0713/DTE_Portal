using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using HRMS.Entities.Models;
using HRMS.Entities.ViewModels;
using HRMS.Infrastructure.Contract;
using Microsoft.EntityFrameworkCore;
using TechnicalEducationPortal.Data;

namespace HRMS.Infrastructure.Repository
{
    public class BlockRepository : IBlockRepository
    {
        private readonly ApplicationDbContext _context;
        public BlockRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<MstBlockVM>> GetAllBlockAsync()
        {
            var blocks = await (from block in _context.MstBlocks
                                join state in _context.MstStates on block.StateId equals state.StateId
                                join division in _context.MstDivisions on block.DivisionId equals division.DivisionId
                                join district in _context.MstDistricts on block.DistrictId equals district.DistrictId
                                select new MstBlockVM
                                {
                                    BlockId = block.BlockId,
                                    StateNameEng = state.StateNameEng,
                                    DivisionNameEng = division.DivisionNameEng,
                                    DistrictNameEng = district.DistrictNameEng,
                                    BlockNameEng = block.BlockNameEng,
                                    BlockNameHin = block.BlockNameHin,
                                    BlockCode = block.BlockCode,
                                    IsActive = block.IsActive
                                }).ToListAsync();
            return blocks;
        }
        public async Task<bool> AddBlockAsync(MstBlock mstBlock)
        {
            var existName = _context.MstBlocks.Where(x => x.BlockCode == mstBlock.BlockCode).FirstOrDefaultAsync();
            if (existName == null)
            {
                await _context.MstBlocks.AddAsync(mstBlock);
                return true;
            }
            else
            {
                return false;
            }
        }
        public async Task<MstBlock> GetBlockByIdAsync(int blockId)
        {
            return await _context.MstBlocks.Where(x => x.BlockId == blockId).FirstOrDefaultAsync();
        }
        public async Task<bool> UpdateBlockAsync(MstBlock mstBlock)
        {
            var existName = await _context.MstBlocks.Where(x => x.BlockCode == mstBlock.BlockCode).FirstOrDefaultAsync();
            if (existName == null)
            {
                _context.MstBlocks.Update(mstBlock);
                return true;

            }
            else
            {
                return false;
            }

        }
    }
}
