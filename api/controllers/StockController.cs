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

        [HttpGet("{id}")]
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
        public IActionResult Post([FromBody] StockPostRequestDTO stockPostRequestDTO) {
            Stock stock = stockPostRequestDTO.ToStockFromStockPostRequestDto();

            context.Add(stock);
            context.SaveChanges();

            return CreatedAtAction(nameof(GetById), new { id = stock.StockId}, stock.ToStockDTO());
        }
        #endregion
        #endregion
    }
}