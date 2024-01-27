using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.models;

namespace api.interfaces
{
    public interface ICommentRepository
    {
        #region Public Methods
        #region Gets
        Task<List<Comment>> GetAllAsync();
        #endregion
        #endregion
    }
}