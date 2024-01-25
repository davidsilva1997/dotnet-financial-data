using api.data;
using api.dtos.Stock;
using api.mappers;
using api.models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
        public async Task<IActionResult> GetAll() {
            var stocks = await context.Stocks.ToListAsync();

            var stocksDTO = stocks.Select(select => select.ToStockDTO());

            return Ok(stocksDTO);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetById([FromRoute] Guid id) {
            Stock? stock = await context.Stocks.FindAsync(id);

            if (stock == null) {
                return NotFound();
            }

            return Ok(stock.ToStockDTO());
        }
        #endregion

        #region Posts
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] StockRequestDTO StockRequestDTO) {
            Stock stock = StockRequestDTO.ToStockFromStockRequestDto();

            await context.AddAsync(stock);
            await context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetById), new { id = stock.StockId}, stock.ToStockDTO());
        }
        #endregion
        
        #region Puts
        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> Put([FromRoute] Guid id, [FromBody] StockRequestDTO stockRequestDTO) {
            var stock = await context.Stocks.SingleOrDefaultAsync(single => single.StockId == id);

            if (stock == null) {
                return NotFound();
            }

            stock.Symbol = stockRequestDTO.Symbol;
            stock.CompanyName = stockRequestDTO.CompanyName;
            stock.Industry = stockRequestDTO.Industry;
            stock.Purchase = stockRequestDTO.Purchase;
            stock.Dividend = stockRequestDTO.Dividend;
            stock.MarketCap = stockRequestDTO.MarketCap;

            await context.SaveChangesAsync();

            return Ok(stock.ToStockDTO());
        }
        #endregion
        
        #region Deletes
        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id) {
            var stock = await context.Stocks.SingleOrDefaultAsync(single => single.StockId == id);

            if (stock == null) {
                return NotFound();
            }

            context.Stocks.Remove(stock);
            await context.SaveChangesAsync();

            return NoContent();
        }
        #endregion
        #endregion
    }
}