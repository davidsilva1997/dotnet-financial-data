using System.ComponentModel.DataAnnotations;

namespace api.dtos.Stock
{
    public class StockRequestDTO
    {
        [Required]
        [MaxLength(10, ErrorMessage = "Symbol cannot be over 10 characters")]
        public string Symbol { get; set; } = string.Empty;

        [Required]
        [MaxLength(20, ErrorMessage = "Company name cannot be over 20 characters")]
        public string CompanyName { get; set; } = string.Empty;

        [Required]
        [MaxLength(20, ErrorMessage = "Industry cannot be over 20 characters")]
        public string Industry { get; set; } = string.Empty;

        [Required]
        [Range(0.00000001, 1000000000)]
        public decimal Purchase { get; set; }

        [Required]
        [Range(0.001, 100)]
        public decimal Dividend { get; set; }

        [Required]
        [Range(0.00000001, 10000000000)]
        public long MarketCap { get; set; }
    }
}