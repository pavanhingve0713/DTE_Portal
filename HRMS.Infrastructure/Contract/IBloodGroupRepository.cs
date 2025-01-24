using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HRMS.Entities.Models;

namespace HRMS.Infrastructure.Contract
{
    public interface IBloodGroupRepository
    {
        Task<IEnumerable<MstBloodGroup>> GetAllBloodGroupAsync();
        Task<bool> AddBloodGroupAsync(MstBloodGroup mstBloodGroup);
        Task<MstBloodGroup> GetBloodGroupByIdAsync(int id);
        Task<bool> UpdateBloodGroupAsync(MstBloodGroup mstBloodGroup);
    }
}
