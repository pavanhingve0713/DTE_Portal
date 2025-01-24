using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HRMS.Entities.Models;
using HRMS.Entities.ViewModels;

namespace HRMS.Infrastructure.Contract
{
    public interface IBoardRepository
    {
        Task<IEnumerable<MstBoardVM>> GetAllBoardAsync();
        Task<MstBoard> GetBoardByIdAsync(Int16 boardId);
        Task<bool> AddBoardAsync(MstBoard mstBoard);
        Task<bool> UpdateBoardAsync(MstBoard mstBoard);
    }
}
