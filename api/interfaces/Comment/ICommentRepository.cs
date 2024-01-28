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
        #endregion
    }
}