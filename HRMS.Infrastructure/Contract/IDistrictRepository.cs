using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HRMS.Entities.Models;
using HRMS.Entities.ViewModels;

namespace HRMS.Infrastructure.Contract
{
    public interface IDistrictRepository
    {
        Task<bool> AddDistrictAsync(MstDistrict mstDistrict);
        Task<IEnumerable<MstDistrictVM>> GetAllDistrictAsync();
        Task<MstDistrict> EditDistrictAsync(int districtId);
        Task<bool> UpdateDistrictAsync(MstDistrict mstDistrict);
        //Task<IEnumerable<MstDivision>> GetDivisionsByStateIdAsync(int id);
        Task<IEnumerable<MstDivision>> GetDivisionsByStateIdAsync(int stateId);
        Task<List<MstState>> FillStatesAsync();
    }
}
