using api.dtos.Comment;
using api.models;

namespace api.dtos.Stock
{
    public class StockDTO
    {
        public Guid StockId { get; set; }

        public string Symbol { get; set; } = string.Empty;

        public string CompanyName { get; set; } = string.Empty;

        public string Industry { get; set; } = string.Empty;

        public decimal Purchase { get; set; }

        public decimal Dividend { get; set; }

        public long MarketCap { get; set; }

        public List<CommentDTO> Comments { get; set; } = new List<CommentDTO>();
    }
}