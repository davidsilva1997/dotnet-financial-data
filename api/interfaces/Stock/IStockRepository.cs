using api.models;
using api.dtos.Stock;

namespace api.interfaces
{
    public interface IStockRepository
    {
        #region Public Methods
        #region Gets
        Task<List<Stock>> GetAllAsync();

        Task<Stock?> GetByIdAsync(Guid id);
        #endregion

        #region Posts
        Task<Stock> PostAsync(Stock stock);
        #endregion

        #region Puts
        Task<Stock?> PutAsync(Guid id, StockRequestDTO stockRequestDTO);
        #endregion

        #region Deletes
        Task<Stock?> DeleteAsync(Guid id);
        #endregion
        
        #region Checks
        Task<bool> Exists(Guid id);
        #endregion
        #endregion
    }
}