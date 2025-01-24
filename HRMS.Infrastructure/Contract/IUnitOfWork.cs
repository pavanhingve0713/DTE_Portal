using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HRMS.Infrastructure.Contract;

namespace HRMS.Infrastructure.Contract
{
    public interface IUnitOfWork
    {
        IStatesRepository statesRepository { get; }
        IDivisionRepository divisionRepository { get; }
        IDistrictRepository districtRepository { get; }
        IBlockRepository blockRepository { get; }
        IUserRepository userRepository { get; }
        IReligionsRepository religionsRepository { get; }
        ICasteRepository casteRepository { get; }
        IPostTypeRepository postTypeRepository { get; }       
        IBloodGroupRepository bloodGroupRepository { get; }
        IDesignationTypeRepository designationTypeRepository { get; }
        IBoardRepository boardRepository { get; }
        IEmployeeRepository employeeRepository { get; }
        IParliamentaryRepository parliamentaryRepository { get; }
        IDropDowns dropDowns { get; }
       
        Task CommitTransactionAsync();
    }
}
