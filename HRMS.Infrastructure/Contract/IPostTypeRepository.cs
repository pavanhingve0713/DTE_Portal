using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HRMS.Entities.Models;

namespace HRMS.Infrastructure.Contract
{
    public interface IPostTypeRepository
    {
        Task<IEnumerable<MstPostType>> GetAllPostTypeAsync();
        Task<MstPostType> GetPostTypeByIdAsync(Int16 id);
        Task AddPostTypeAsync(MstPostType postType);
        Task UpdatePostTypeAsync(MstPostType postType);
    }
}
