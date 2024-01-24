using System.ComponentModel.DataAnnotations.Schema;

namespace api.models
{
    public class Stock
    {
        #region Database Properties
        public Guid StockId { get; set; }

        public string Symbol { get; set; } = string.Empty;

        public string CompanyName { get; set; } = string.Empty;

        public string Industry { get; set; } = string.Empty;

        [Column(TypeName = "decimal(18, 2)")]
        public decimal Purchase { get; set; }

        [Column(TypeName = "decimal(18, 2)")]
        public decimal Dividend { get; set; }

        public long MarketCap { get; set; }
        #endregion

        #region Navigation Properties
        public List<Comment> Comments { get; set; } = new List<Comment>();
        #endregion
    }
}