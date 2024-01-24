using api.data;
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
            List<Stock> stocks = context.Stocks.ToList();

            return Ok(stocks);
        }

        [HttpGet("{id}")]
        public IActionResult GetById([FromRoute] Guid id) {
            Stock? stock = context.Stocks.Find(id);

            if (stock == null) {
                return NotFound();
            }

            return Ok(stock);
        }
        #endregion
        #endregion
    }
}