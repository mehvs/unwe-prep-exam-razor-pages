namespace Sample.Data.Models
{
    public class Blog
    {
        public Guid BlogId { get; set; }

        public String Name { get; set; } = string.Empty;

        public String Url { get; set; } = string.Empty;

        public Guid AuthorId { get; set; }

        public Author Author { get; set; } = null!;
        public ICollection<Post> Posts { get; set; } = new List<Post>();
    }
}
