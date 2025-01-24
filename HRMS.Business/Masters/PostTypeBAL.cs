using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HRMS.Entities.Models;
using HRMS.Entities.ViewModels;
using HRMS.Infrastructure.Contract;

namespace HRMS.Business.Masters
{
    public class PostTypeBAL
    {
        private readonly IUnitOfWork _unitOfWork;
        public PostTypeBAL(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<IEnumerable<MstPostTypeVM>> GetAllPostTypeAsync()
        {
            var postTypeList = await _unitOfWork.postTypeRepository.GetAllPostTypeAsync();
            return postTypeList.Select(x => new MstPostTypeVM
            {
                TypeOfPostId = x.TypeOfPostId,
                PostNameEng = x.PostNameEng,
                PostNameHin = x.PostNameHin,
                PostCode = x.PostCode,
                IsActive = x.IsActive
            }).ToList();

        }
        public async Task AddPostTypeAsync(MstPostType postType)
        {
             await _unitOfWork.postTypeRepository.AddPostTypeAsync(postType);
           
        }
        public async Task<MstPostType> GetPostTypeByIdAsync(Int16 id)
        {
            return await _unitOfWork.postTypeRepository.GetPostTypeByIdAsync(id);
        }
        public async Task UpdatePostTypeAsync(MstPostType newPostType)
        {
            await _unitOfWork.postTypeRepository.UpdatePostTypeAsync(newPostType);
            await _unitOfWork.CommitTransactionAsync();
        }

    }
}
