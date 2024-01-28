using api.models;
using api.dtos.Stock;

namespace api.mappers
{
    public static class StockMapper
    {
        public static StockDTO ToStockDTO(this Stock stock)
        {
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

        public static Stock ToStockFromStockRequestDto(this StockRequestDTO stockRequestDTO)
        {
            Stock stock = new Stock
            {
                Symbol = stockRequestDTO.Symbol,
                CompanyName = stockRequestDTO.CompanyName,
                Industry = stockRequestDTO.Industry,
                Purchase = stockRequestDTO.Purchase,
                Dividend = stockRequestDTO.Dividend,
                MarketCap = stockRequestDTO.MarketCap
            };

            return stock;
        }
    }
}