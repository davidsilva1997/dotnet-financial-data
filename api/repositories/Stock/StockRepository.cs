using api.data;
using api.models;
using api.dtos.Stock;
using api.interfaces;
using Microsoft.EntityFrameworkCore;

namespace api.repositories
{
    public class StockRepository : IStockRepository
    {
        #region Properties
        private readonly ApplicationDBContext context;
        #endregion

        #region Constructors
        public StockRepository(ApplicationDBContext context)
        {
            this.context = context;
        }
        #endregion

        #region Public Methods
        #region Gets
        public async Task<List<Stock>> GetAllAsync()
        {
            return await context.Stocks.Include(include => include.Comments).ToListAsync();
        }

        public async Task<Stock?> GetByIdAsync(Guid id)
        {
            return await context.Stocks.Include(include => include.Comments).SingleOrDefaultAsync(single => single.StockId == id);
        }
        #endregion

        #region Posts
        public async Task<Stock> PostAsync(Stock stock)
        {
            await context.AddAsync(stock);
            await context.SaveChangesAsync();

            return stock;
        }
        #endregion

        #region Puts
        public async Task<Stock?> PutAsync(Guid id, StockRequestDTO stockRequestDTO)
        {
            var stock = await context.Stocks.SingleOrDefaultAsync(single => single.StockId == id);

            if (stock == null) {
                return null;
            }

            stock.Symbol = stockRequestDTO.Symbol;
            stock.CompanyName = stockRequestDTO.CompanyName;
            stock.Industry = stockRequestDTO.Industry;
            stock.Purchase = stockRequestDTO.Purchase;
            stock.Dividend = stockRequestDTO.Dividend;
            stock.MarketCap = stockRequestDTO.MarketCap;

            await context.SaveChangesAsync();

            return stock;
        }
        #endregion

        #region Deletes
        public async Task<Stock?> DeleteAsync(Guid id)
        {
            var stock = await context.Stocks.SingleOrDefaultAsync(single => single.StockId == id);

            if (stock == null) {
                return null;
            }

            context.Stocks.Remove(stock);
            await context.SaveChangesAsync();

            return stock;
        }
        #endregion
        #endregion
    }
}