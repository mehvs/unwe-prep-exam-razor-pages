using System.ComponentModel.DataAnnotations;

namespace Sample.Data.Models
{
    public class Author
    {
        public Guid AuthorId { get; set; }

        public String FirstName { get; set; } = string.Empty;

        public String LastName { get; set; } = string.Empty;

        [Required]
        public String DisplayName { get; set; } = string.Empty;

        [Required]
        [EmailAddress]
        public String Email { get; set; } = string.Empty;
        public ICollection<Blog> Blogs { get; set; } = new List<Blog>();
    }
}
