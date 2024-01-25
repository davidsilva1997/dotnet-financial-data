namespace api.dtos.Stock
{
    public class StockRequestDTO
    {
        public string Symbol { get; set; } = string.Empty;

        public string CompanyName { get; set; } = string.Empty;

        public string Industry { get; set; } = string.Empty;

        public decimal Purchase { get; set; }

        public decimal Dividend { get; set; }

        public long MarketCap { get; set; }
    }
}