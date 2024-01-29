using System.ComponentModel.DataAnnotations;

namespace api.dtos.Comment
{
    public class CommentRequestDTO
    {
        [Required]
        [MinLength(5, ErrorMessage = "Title must have at least 5 characters.")]
        [MaxLength(280, ErrorMessage = "Title cannot be over 280 characters.")]
        public string Title { get; set; } = string.Empty;

        [Required]
        [MinLength(5, ErrorMessage = "Content must have at least 5 characters.")]
        [MaxLength(280, ErrorMessage = "Content cannot be over 280 characters.")]
        public string Content { get; set; } = string.Empty;
    }
}