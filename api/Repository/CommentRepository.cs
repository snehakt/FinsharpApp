using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Interfaces;
using api.Models;
using api.Data;
using Microsoft.EntityFrameworkCore;
using api.Dto.Comment;

namespace api.Repository
{
    public class CommentRepository : ICommentRepository
    {
        private readonly ApplicationDbContext _context;
        public CommentRepository(ApplicationDbContext context)
        {
            _context=context;
        }
        public async Task<List<Comment>> GetAllAsync(){
            return await _context.Comments.ToListAsync();
        }

       public async Task<Comment?> GetByIDAsync(int id){
        return await _context.Comments.FindAsync(id);
       } 

       public async Task<Comment> CreateAsync(Comment commentModel){
        await _context.Comments.AddAsync(commentModel);
        await _context.SaveChangesAsync();
        return commentModel;
       }

         public async Task<Comment?> UpdateAsync(int id, Comment commentModel)
        {
            var existingComment = await _context.Comments.FindAsync(id);

            if (existingComment == null)
            {
                return null;
            }

            existingComment.Title = commentModel.Title;
            existingComment.Content = commentModel.Content;

            await _context.SaveChangesAsync();

            return existingComment;
        }

       public async Task<Comment> DeleteAsync(int id){
        var commentModel = await _context.Comments.FirstOrDefaultAsync(x=>x.Id==id);
        if(commentModel==null){
            return null;
        }
        _context.Comments.Remove(commentModel);
        await _context.SaveChangesAsync();
        return commentModel;
       }
    }
}