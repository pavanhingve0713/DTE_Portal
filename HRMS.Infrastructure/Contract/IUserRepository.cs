using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HRMS.Entities.Models;

namespace HRMS.Infrastructure.Contract
{
    public interface IUserRepository
    {
        Task AddUserAsync(UserDetail user);
        Task<UserDetail> GetUserByEmailAsync(string email);
    }
}
