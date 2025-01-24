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
    public class PostTypeRepository : IPostTypeRepository
    {
        private readonly ApplicationDbContext _context;
        public PostTypeRepository(ApplicationDbContext context)
        {
            _context = context;
        }   
        public async Task<IEnumerable<MstPostType>> GetAllPostTypeAsync()
        {
            return await _context.MstPostTypes.ToListAsync();
        }
        public async Task<MstPostType> GetPostTypeByIdAsync(Int16 id)
        {
            return await _context.MstPostTypes.FindAsync(id);
            
        }
        public async Task AddPostTypeAsync(MstPostType postType)
        {
            await _context.MstPostTypes.AddAsync(postType);
            await _context.SaveChangesAsync();
        }
        public async Task UpdatePostTypeAsync(MstPostType postType)
        {
             _context.MstPostTypes.Update(postType);
            await _context.SaveChangesAsync();
        }
    }
}
