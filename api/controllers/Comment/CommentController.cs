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
        public async Task<IActionResult> GetAllAsync()
        {
            var comments = await commentRepository.GetAllAsync();

            var commentsDTO = comments.Select(select => select.ToCommentDTO());

            return Ok(comments);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetByIdAsync([FromRoute] Guid id)
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
        [Route("{stockId}")]
        public async Task<IActionResult> Post([FromRoute] Guid stockId, CommentRequestDTO commentRequestDTO)
        {
            bool stockExists = await stockRepository.Exists(stockId);

            if (!stockExists)
            {
                return BadRequest("Stock does not exist.");
            }

            var comment = commentRequestDTO.ToCommentFromCommentRequestDto(stockId);

            await commentRepository.PostAsync(comment);

            return CreatedAtAction(nameof(GetByIdAsync), new { id = comment.CommentId }, comment.ToCommentDTO());
        }
        #endregion
        #endregion
    }
}