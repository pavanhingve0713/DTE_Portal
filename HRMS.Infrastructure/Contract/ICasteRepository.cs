using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HRMS.Entities.Models;

namespace HRMS.Infrastructure.Contract
{
    public interface ICasteRepository
    {
        Task<IEnumerable<MstCaste>> GetAllCasteAsync();
        Task AddCasteAsync(MstCaste mstCaste);
        Task<MstCaste> GetCasteByIdAsync(int id);
        Task UpdateCasteAsync(MstCaste mstCaste);
    }
}
