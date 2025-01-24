using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HRMS.Infrastructure.Contract;
using TechnicalEducationPortal.Data;

namespace HRMS.Infrastructure.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        readonly ApplicationDbContext _context;
        public UnitOfWork(ApplicationDbContext Context)
        {
            _context = Context;
        }
        public IStatesRepository statesRepository => new StatesRepository(_context);
        public IDivisionRepository divisionRepository => new DivisionRepository(_context);
        public IDistrictRepository districtRepository => new DistrictRepository(_context);
        public IBlockRepository blockRepository => new BlockRepository(_context);
        public IReligionsRepository religionsRepository => new ReligionsRepository(_context);
        public ICasteRepository casteRepository => new CasteRepository(_context);
        public IPostTypeRepository postTypeRepository => new PostTypeRepository(_context);       
        public IBloodGroupRepository bloodGroupRepository => new BloodGroupRepository(_context);
        public IDesignationTypeRepository designationTypeRepository => new DesignationTypeRepository(_context);
        public IBoardRepository boardRepository => new BoardRepository(_context);       
        public IUserRepository userRepository => new UserRepository(_context);
        public IEmployeeRepository employeeRepository => new EmployeeRepository(_context);
        public IParliamentaryRepository parliamentaryRepository => new ParliamentaryRepository(_context);
        public IDropDowns dropDowns => new DropDowns(_context);
        public async Task CommitTransactionAsync()
        {
            await _context.SaveChangesAsync().ConfigureAwait(false);
        }
    }
}
