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
    public class BoardBAL
    {
        private readonly IUnitOfWork _unitOfWork;
        public BoardBAL(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
       public async Task<IEnumerable<MstBoardVM>> GetAllBoardAsync()
        {
            return await _unitOfWork.boardRepository.GetAllBoardAsync();
        }
        public async Task<MstBoard> GetBoardByIdAsync(Int16 boardId)
        {
            var result = await _unitOfWork.boardRepository.GetBoardByIdAsync(boardId);
            return result;

        }
        public async Task<bool> AddBoardAsync(MstBoard mstBoard)
        {
            var result = await _unitOfWork.boardRepository.AddBoardAsync(mstBoard);
            await _unitOfWork.CommitTransactionAsync();
            return result;

        }
        public async Task<bool> UpdateBoardAsync(MstBoard mstBoard)
        {
            var result = await _unitOfWork.boardRepository.UpdateBoardAsync(mstBoard);
            await _unitOfWork.CommitTransactionAsync();
            return result;

        }
    }
}
