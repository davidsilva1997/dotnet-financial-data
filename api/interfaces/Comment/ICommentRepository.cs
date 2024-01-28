using api.dtos.Comment;
using api.models;

namespace api.interfaces
{
    public interface ICommentRepository
    {
        #region Public Methods
        #region Gets
        Task<List<Comment>> GetAllAsync();

        Task<Comment?> GetByIdAsync(Guid id);
        #endregion

        #region Posts
        Task<Comment> PostAsync(Comment comment);
        #endregion

        #region Puts
        Task<Comment?> PutAsync(Guid id, CommentRequestDTO commentRequestDTO);
        #endregion

        #region Deletes
        Task<Comment?> DeleteAsync(Guid id);
        #endregion
        #endregion
    }
}