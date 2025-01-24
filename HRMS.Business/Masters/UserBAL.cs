using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HRMS.Entities.Models;
using HRMS.Infrastructure.Contract;

namespace HRMS.Business.Masters
{
    public class UserBAL
    {
        private readonly IUnitOfWork _unitOfWork;
        public UserBAL(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task RegisterUserAsync(UserDetail userDetail)
        {
            await _unitOfWork.userRepository.AddUserAsync(userDetail);
        }
        public async Task<UserDetail> AuthenticateUser(string email, string password)
        {
            var user = await _unitOfWork.userRepository.GetUserByEmailAsync(email);
            if (user != null && user.Password == password) // Direct comparison of plain text password
            {
                return user; // User authenticated successfully
            }
            return null; // Invalid credentials
        }
    }
}
