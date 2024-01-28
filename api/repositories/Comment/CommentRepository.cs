using api.data;
using api.models;
using api.interfaces;
using Microsoft.EntityFrameworkCore;
using api.dtos.Comment;

namespace api.repositories
{
    public class CommentRepository : ICommentRepository
    {
        #region Properties
        private readonly ApplicationDBContext context;
        #endregion

        #region Constructors
        public CommentRepository(ApplicationDBContext context)
        {
            this.context = context;
        }
        #endregion

        #region Public Methods
        #region Gets
        public async Task<List<Comment>> GetAllAsync()
        {
            return await context.Comments.ToListAsync();
        }

        public async Task<Comment?> GetByIdAsync(Guid id)
        {
            return await context.Comments.FindAsync(id);
        }
        #endregion

        #region Posts
        public async Task<Comment> PostAsync(Comment comment)
        {
            await context.Comments.AddAsync(comment);
            await context.SaveChangesAsync();

            return comment;
        }
        #endregion

        #region Puts
        public async Task<Comment?> PutAsync(Guid id, CommentRequestDTO commentRequestDTO)
        {
            var comment = await context.Comments.SingleOrDefaultAsync(single => single.CommentId == id);

            if (comment == null)
            {
                return null;
            }

            comment.Title = commentRequestDTO.Title;
            comment.Content = commentRequestDTO.Content;

            await context.SaveChangesAsync();

            return comment;
        }
        #endregion

        #region Deletes
        public async Task<Comment?> DeleteAsync(Guid id)
        {
            var comment = await context.Comments.SingleOrDefaultAsync(single => single.CommentId == id);

            if (comment == null)
            {
                return null;
            }

            context.Comments.Remove(comment);
            await context.SaveChangesAsync();

            return comment;
        }
        #endregion
        #endregion
    }
}