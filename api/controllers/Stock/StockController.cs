using api.models;
using api.helpers;
using api.mappers;
using api.interfaces;
using api.dtos.Stock;
using Microsoft.AspNetCore.Mvc;

namespace api.controllers
{
    [Route("api/stock")]
    [ApiController]
    public class StockController : ControllerBase
    {
        #region Properties
        private readonly IStockRepository stockRepository;
        #endregion

        #region Constructors
        public StockController(IStockRepository stockRepository)
        {
            this.stockRepository = stockRepository;
        }
        #endregion

        #region Public Methods
        #region Gets
        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] QueryObject queryObject) 
        {
            var stocks = await stockRepository.GetAllAsync(queryObject);

            var stocksDTO = stocks.Select(select => select.ToStockDTO());

            return Ok(stocksDTO);
        }

        [HttpGet]
        [Route("{id:guid}")]
        public async Task<IActionResult> GetById([FromRoute] Guid id) 
        {
            Stock? stock = await stockRepository.GetByIdAsync(id);

            if (stock == null) {
                return NotFound();
            }

            return Ok(stock.ToStockDTO());
        }
        #endregion

        #region Posts
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] StockRequestDTO StockRequestDTO) 
        {
            Stock stock = StockRequestDTO.ToStockFromStockRequestDto();

            await stockRepository.PostAsync(stock);

            return CreatedAtAction(nameof(GetById), new { id = stock.StockId}, stock.ToStockDTO());
        }
        #endregion
        
        #region Puts
        [HttpPut]
        [Route("{id:guid}")]
        public async Task<IActionResult> Put([FromRoute] Guid id, [FromBody] StockRequestDTO stockRequestDTO) 
        {
            var stock = await stockRepository.PutAsync(id, stockRequestDTO);

            if (stock == null) {
                return NotFound();
            }

            return Ok(stock.ToStockDTO());
        }
        #endregion
        
        #region Deletes
        [HttpDelete]
        [Route("{id:guid}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id) 
        {
            var stock = await stockRepository.DeleteAsync(id);

            if (stock == null) {
                return NotFound();
            }

            return NoContent();
        }
        #endregion
        #endregion
    }
}