using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HRMS.Entities.Models;

namespace HRMS.Infrastructure.Contract
{
    public interface IParliamentaryRepository
    {
        Task<IEnumerable<MstParliamentary>> GetAllParliamentaryAsync();
        Task<MstParliamentary> GetParliamentaryByIdAsync(int id);
        Task<bool> AddParliamentaryAsync(MstParliamentary mstParliamentary);
        Task<bool> UpdateParliamentaryAsync(MstParliamentary mstParliamentary);
        Task DeleteParliamentaryAsync(int id);
    }
}
