using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HRMS.Entities.Models;
using HRMS.Infrastructure.Contract;
using Microsoft.EntityFrameworkCore;
using TechnicalEducationPortal.Data;

namespace HRMS.Infrastructure.Repository
{
    public class UserRepository :IUserRepository 
    {
        private readonly ApplicationDbContext _context;
        public UserRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task AddUserAsync(UserDetail user)
        {
            await _context.UserDetails.AddAsync(user);
            await _context.SaveChangesAsync();
        }
        public async Task<UserDetail> GetUserByEmailAsync(string email)
        {
            return await _context.UserDetails.FirstOrDefaultAsync(u => u.Email == email);
        }
    }
}
