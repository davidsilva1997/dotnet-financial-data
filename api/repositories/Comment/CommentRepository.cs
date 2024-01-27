using api.data;
using api.models;
using api.interfaces;
using Microsoft.EntityFrameworkCore;

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
        #endregion
        #endregion
    }
}