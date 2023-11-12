using System.ComponentModel.DataAnnotations;

namespace Sample.Data.Models
{
    public class Post
    {
        public Guid PostId { get; set; }

        public Guid BlogId { get; set; }

        public Blog Blog { get; set; } = null!;

        [Required]
        public String Content { get; set; } = string.Empty;

        [Required]
        [MaxLength(100)]
        public String Title { get; set; } = string.Empty;

        public DateTime DatePublished { get; set; }
    }
}
