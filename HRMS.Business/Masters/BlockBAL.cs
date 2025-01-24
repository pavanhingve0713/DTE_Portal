using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HRMS.Entities.Models;
using HRMS.Entities.ViewModels;
using HRMS.Infrastructure.Contract;

namespace HRMS.Business.Masters
{
    public class BlockBAL
    {
        private readonly IUnitOfWork _unitOfWork;
        public BlockBAL(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<IEnumerable<MstBlockVM>> GetAllBlockAsync()
        {
            return await _unitOfWork.blockRepository.GetAllBlockAsync();
        }
        public async Task<bool> AddBlockAsync(MstBlock mstBlock)
        {
           var result = await _unitOfWork.blockRepository.AddBlockAsync(mstBlock);
            await _unitOfWork.CommitTransactionAsync();
            return result;
        }
        public async Task<MstBlock> GetBlockByIdAsync(int blockId)
        {
            return await _unitOfWork.blockRepository.GetBlockByIdAsync(blockId); 
        }
        public async Task<bool> UpdateBlockAsync(MstBlock mstBlock)
        {
            var result = await _unitOfWork.blockRepository.UpdateBlockAsync(mstBlock);
            await _unitOfWork.CommitTransactionAsync();
            return result;
        }
    }
}
