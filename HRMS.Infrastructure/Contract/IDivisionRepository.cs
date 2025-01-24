using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HRMS.Entities.Models;
using HRMS.Entities.ViewModels;

namespace HRMS.Infrastructure.Contract
{
    public interface IDivisionRepository
    {
        Task<IEnumerable<MstDivisionVM>> GetAllDivisionAsync();
        Task<MstDivision> GetDivisionByIdAsync(int id);
        Task InsertDivisionAsync(MstDivision mstDivision);
        Task<IEnumerable<MstState>> GetAllStatesAsync();
        Task UpdateState(MstDivision mstDivision);
    }
}
