using api.models;
using api.dtos.Comment;

namespace api.mappers
{
    public static class CommentMapper
    {
        public static CommentDTO ToCommentDTO(this Comment comment) {
            CommentDTO commentDTO = new CommentDTO 
            {
                CommentId = comment.CommentId,
                Title = comment.Title,
                Content = comment.Content,
                CreationDateTime = comment.CreationDateTime,
                StockId = comment.StockId
            };

            return commentDTO;
        }

        public static Comment ToCommentFromCommentRequestDto(this CommentRequestDTO commentRequestDTO, Guid stockId)
        {
            Comment comment = new Comment
            {
                Title = commentRequestDTO.Title,
                Content = commentRequestDTO.Content,
                StockId = stockId
            };

            return comment;
        }
    }
}