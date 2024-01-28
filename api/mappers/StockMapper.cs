using api.models;
using api.dtos.Stock;

namespace api.mappers
{
    public static class StockMapper
    {
        public static StockDTO ToStockDTO(this Stock stock) {
            StockDTO stockDTO = new StockDTO 
            {
                StockId = stock.StockId,
                Symbol = stock.Symbol,
                CompanyName = stock.CompanyName,
                Industry = stock.Industry,
                Purchase = stock.Purchase,
                Dividend = stock.Dividend,
                MarketCap = stock.MarketCap,
                Comments = stock.Comments.Select(select => select.ToCommentDTO()).ToList()
            };

            return stockDTO;
        }

        public static Stock ToStockFromStockRequestDto(this StockRequestDTO StockRequestDTO) {
            Stock stock = new Stock {
                Symbol = StockRequestDTO.Symbol,
                CompanyName = StockRequestDTO.CompanyName,
                Industry = StockRequestDTO.Industry,
                Purchase = StockRequestDTO.Purchase,
                Dividend = StockRequestDTO.Dividend,
                MarketCap = StockRequestDTO.MarketCap
            };

            return stock;
        }
    }
}