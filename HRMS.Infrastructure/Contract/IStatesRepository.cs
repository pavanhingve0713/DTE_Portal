using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HRMS.Entities.Models;

namespace HRMS.Infrastructure.Contract
{
    public interface IStatesRepository : IDisposable
    {
        Task<IEnumerable<MstState>> GetAllStateAsync();
        Task<MstState> GetStateByIdAsync(Int16 id);
        Task InsertStateAsync(MstState mstState);
        Task UpdateState(MstState mstState);
    }
}
