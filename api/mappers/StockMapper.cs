using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.dtos.Stock;
using api.models;

namespace api.mappers
{
    public static class StockMapper
    {
        public static StockDTO ToStockDTO(this Stock stock) {
            StockDTO stockDTO = new StockDTO {
                StockId = stock.StockId,
                Symbol = stock.Symbol,
                CompanyName = stock.CompanyName,
                Industry = stock.Industry,
                Purchase = stock.Purchase,
                Dividend = stock.Dividend,
                MarketCap = stock.MarketCap
            };

            return stockDTO;
        }

        public static Stock ToStockFromStockPostRequestDto(this StockPostRequestDTO stockPostRequestDTO) {
            Stock stock = new Stock {
                Symbol = stockPostRequestDTO.Symbol,
                CompanyName = stockPostRequestDTO.CompanyName,
                Industry = stockPostRequestDTO.Industry,
                Purchase = stockPostRequestDTO.Purchase,
                Dividend = stockPostRequestDTO.Dividend,
                MarketCap = stockPostRequestDTO.MarketCap
            };

            return stock;
        }
    }
}