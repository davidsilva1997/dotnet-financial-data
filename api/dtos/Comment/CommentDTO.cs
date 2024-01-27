namespace api.dtos.Comment
{
    public class CommentDTO
    {
        public Guid CommentId { get; set; }

        public string Title { get; set; } = string.Empty;

        public string Content { get; set; } = string.Empty;

        public DateTime CreationDateTime { get; set; } = DateTime.Now;

        public Guid? StockId { get; set; }
    }
}