using api.data;
using api.dtos.Stock;
using api.mappers;
using api.models;
using Microsoft.AspNetCore.Mvc;

namespace api.controllers
{
    [Route("api/stock")]
    [ApiController]
    public class StockController : ControllerBase
    {
        #region Properties
        private readonly ApplicationDBContext context;
        #endregion

        #region Constructors
        public StockController(ApplicationDBContext context)
        {
            this.context = context;
        }
        #endregion

        #region Public Methods
        #region Gets
        [HttpGet]
        public IActionResult GetAll() {
            var stocks = context.Stocks.ToList().Select(select => select.ToStockDTO());

            return Ok(stocks);
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult GetById([FromRoute] Guid id) {
            Stock? stock = context.Stocks.Find(id);

            if (stock == null) {
                return NotFound();
            }

            return Ok(stock.ToStockDTO());
        }
        #endregion

        #region Posts
        [HttpPost]
        public IActionResult Post([FromBody] StockRequestDTO StockRequestDTO) {
            Stock stock = StockRequestDTO.ToStockFromStockRequestDto();

            context.Add(stock);
            context.SaveChanges();

            return CreatedAtAction(nameof(GetById), new { id = stock.StockId}, stock.ToStockDTO());
        }
        #endregion
        
        #region Puts
        [HttpPut]
        [Route("{id}")]
        public IActionResult Put([FromRoute] Guid id, [FromBody] StockRequestDTO stockRequestDTO) {
            var stock = context.Stocks.SingleOrDefault(single => single.StockId == id);

            if (stock == null) {
                return NotFound();
            }

            stock.Symbol = stockRequestDTO.Symbol;
            stock.CompanyName = stockRequestDTO.CompanyName;
            stock.Industry = stockRequestDTO.Industry;
            stock.Purchase = stockRequestDTO.Purchase;
            stock.Dividend = stockRequestDTO.Dividend;
            stock.MarketCap = stockRequestDTO.MarketCap;

            context.SaveChanges();

            return Ok(stock.ToStockDTO());
        }
        #endregion
        #endregion
    }
}