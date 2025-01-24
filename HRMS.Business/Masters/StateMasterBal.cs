using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HRMS.Entities.Models;
using HRMS.Infrastructure.Contract;
using TechnicalEducationPortal.DAL;

namespace HRMS.Business.Masters
{
    namespace HRMS.Business.Masters
    {
        public class StateMasterBL
        {
            private readonly IUnitOfWork _unitOfWork;
            private readonly IDbOperations _dbOperations;

            public StateMasterBL(IUnitOfWork unitOfWork)
            {
                _unitOfWork = unitOfWork;
            }

            public async Task<IEnumerable<MstState>> GetAllStateAsync()
            {
                    return await _unitOfWork.statesRepository.GetAllStateAsync();
            }

            public async Task InsertStateAsync(MstState mstState)
            {               
                    await _unitOfWork.statesRepository.InsertStateAsync(mstState);
                    await _unitOfWork.CommitTransactionAsync();                  
            }

            public async Task<MstState> GetStateByIdAsync(Int16 id)
            {               
                    return await _unitOfWork.statesRepository.GetStateByIdAsync(id);                   
            }

            public async Task UpdateStateAsync(MstState mstState)
            {
                await _unitOfWork.statesRepository.UpdateState(mstState);
                await _unitOfWork.CommitTransactionAsync();
            }

        }
    }

}
