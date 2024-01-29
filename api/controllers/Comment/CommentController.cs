using api.models;
using api.mappers;
using api.interfaces;
using api.dtos.Stock;
using Microsoft.AspNetCore.Mvc;
using api.dtos.Comment;

namespace api.controllers
{
    [Route("api/comment")]
    [ApiController]
    public class CommentController : ControllerBase
    {
        #region Properties
        private readonly ICommentRepository commentRepository;
        private readonly IStockRepository stockRepository;
        #endregion

        #region Constructors
        public CommentController(ICommentRepository commentRepository, IStockRepository stockRepository)
        {
            this.commentRepository = commentRepository;
            this.stockRepository = stockRepository;
        }
        #endregion

        #region Public Methods
        #region Gets
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var comments = await commentRepository.GetAllAsync();

            var commentsDTO = comments.Select(select => select.ToCommentDTO());

            return Ok(comments);
        }

        [HttpGet]
        [Route("{id:guid}")]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            var comment = await commentRepository.GetByIdAsync(id);

            if (comment == null)
            {
                return NotFound();
            }

            return Ok(comment.ToCommentDTO());
        }
        #endregion

        #region Posts
        [HttpPost]
        [Route("{stockId:guid}")]
        public async Task<IActionResult> Post([FromRoute] Guid stockId, CommentRequestDTO commentRequestDTO)
        {
            bool stockExists = await stockRepository.Exists(stockId);

            if (!stockExists)
            {
                return BadRequest("Stock does not exist.");
            }

            var comment = commentRequestDTO.ToCommentFromCommentRequestDto(stockId);

            await commentRepository.PostAsync(comment);

            return CreatedAtAction(nameof(GetById), new { id = comment.CommentId }, comment.ToCommentDTO());
        }
        #endregion

        #region Puts
        [HttpPut]
        [Route("{id:guid}")]
        public async Task<IActionResult> Put([FromRoute] Guid id, [FromBody] CommentRequestDTO commentRequestDTO)
        {
            var comment = await commentRepository.PutAsync(id, commentRequestDTO);

            if (comment == null)
            {
                return NotFound("Comment does not exist.");
            }

            return Ok(comment.ToCommentDTO());
        }
        #endregion

        #region Deletes
        [HttpDelete]
        [Route("{id:guid}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            var comment = await commentRepository.DeleteAsync(id);

            if (comment == null)
            {
                return NotFound("Comment does not exist.");
            }

            return NoContent();
        }
        #endregion
        #endregion
    }
}