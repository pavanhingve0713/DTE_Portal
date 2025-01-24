using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HRMS.Entities.Models;

namespace HRMS.Infrastructure.Contract
{
    public interface IReligionsRepository
    {
        Task<IEnumerable<MstReligion>> GetAllReligionsAsync();
        Task<MstReligion> GetReligionByIdAsync(int id);
        Task AddReligionAsync(MstReligion mstReligion);
        Task UpdateReligionAsync(MstReligion mstReligion);
    }
}
