using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HRMS.Entities.Models;
using HRMS.Entities.ViewModels;

namespace HRMS.Infrastructure.Contract
{
    public interface IBlockRepository
    {
        Task<IEnumerable<MstBlockVM>> GetAllBlockAsync();
        Task<bool> AddBlockAsync(MstBlock mstBlock);
        Task<MstBlock> GetBlockByIdAsync(int blockId);
        Task<bool> UpdateBlockAsync(MstBlock mstBlock);
    }
}
