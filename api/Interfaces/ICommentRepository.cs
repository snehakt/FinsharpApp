using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Helpers;
using api.Models;
using api.Dto.Comment;

namespace api.Interfaces
{
    public interface ICommentRepository
    {
         Task<List<Comment>> GetAllAsync(CommentQueryObject queryObject);
         Task<Comment> GetByIDAsync(int id);
         Task<Comment> CreateAsync(Comment commentModel);
          Task<Comment?> UpdateAsync(int id, Comment commentModel);
         Task<Comment?> DeleteAsync(int id); 
         
    }
}