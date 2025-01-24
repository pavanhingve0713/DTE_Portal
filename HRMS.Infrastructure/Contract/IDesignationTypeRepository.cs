using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HRMS.Entities.Models;
using HRMS.Entities.ViewModels;

namespace HRMS.Infrastructure.Contract
{
    public interface IDesignationTypeRepository
    {
        Task<IEnumerable<MstDesignationTypeVM>> GetAllDesignationTypeAsync();
        Task<bool> AddDesignationTypeAsync(MstDesignationType mstDesignationType);
        Task<MstDesignationType> GetDesignationTypeByIdAsync(int designationTypeId);
        Task<bool> UpdateDesignationTypeAsync(MstDesignationType mstDesignationType);
    }
}
