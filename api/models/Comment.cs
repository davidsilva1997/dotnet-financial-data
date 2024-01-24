using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace api.models
{
    public class Comment
    {
        #region Database Properties
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid CommentId { get; set; }

        public string Title { get; set; } = string.Empty;

        public string Content { get; set; } = string.Empty;

        public DateTime CreationDateTime { get; set; } = DateTime.Now;

        public Guid? StockId { get; set; }
        #endregion

        #region Navigation Properties
        public Stock? Stock { get; set; }
        #endregion
    }
}