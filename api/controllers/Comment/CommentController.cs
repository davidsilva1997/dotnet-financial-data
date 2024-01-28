using api.models;
using api.mappers;
using api.interfaces;
using api.dtos.Stock;
using Microsoft.AspNetCore.Mvc;

namespace api.controllers
{
    [Route("api/comment")]
    [ApiController]
    public class CommentController : ControllerBase
    {
        #region Properties
        private readonly ICommentRepository commentRepository;
        #endregion

        #region Constructors
        public CommentController(ICommentRepository commentRepository)
        {
            this.commentRepository = commentRepository;
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
        #endregion
    }
}