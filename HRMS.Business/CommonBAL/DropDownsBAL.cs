using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HRMS.Entities.Models;
using HRMS.Entities.ViewModels;
using HRMS.Infrastructure.Contract;
using HRMS.Infrastructure.Repository;
using TechnicalEducationPortal.Data;

namespace HRMS.Business.CommonBAL
{
    public class DropDownsBAL
    {
        private readonly IDropDowns _dropDowns;
        public DropDownsBAL(IDropDowns dropDowns)
        {
            _dropDowns = dropDowns; 
        }
        public async Task<IEnumerable<MstDivision>> GetDivisionsByStateIdAsync(int stateId)
        {
            return await _dropDowns.GetDivisionsByStateIdAsync(stateId);
        }
        public async Task<List<MstState>> FillStatesAsync()
        {
            return await _dropDowns.FillStatesAsync();
        }
    }

}
