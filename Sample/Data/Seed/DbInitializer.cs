using Sample.Data.Context;
using Sample.Data.Models;

namespace Sample.Data.Seed
{
    public class DbInitializer
    {
        public static void Initialize(SampleContext context)
        {
            context.Database.EnsureCreated();

            if (!context.Authors.Any() && !context.Blogs.Any() && !context.Posts.Any())
            {



                var authors = new List<Author>
            {
                new Author
                {
                    AuthorId = Guid.NewGuid(),
                    FirstName = "John",
                    LastName = "Doe",
                    DisplayName = "JohnDoe",
                    Email = "johndoe@email.com"
                },
                new Author
                {
                    AuthorId = Guid.NewGuid(),
                    FirstName = "Jane",
                    LastName = "Smith",
                    DisplayName = "JaneSmith",
                    Email = "janesmith@email.com"
                }
            };

                context.Authors.AddRange(authors);

                var blogs = new List<Blog>
            {
                new Blog
                {
                    BlogId = Guid.NewGuid(),
                    Name = "Tech Blog",
                    Url = "https://techblog.com",
                    AuthorId = authors[0].AuthorId
                },
                new Blog
                {
                    BlogId = Guid.NewGuid(),
                    Name = "Travel Blog",
                    Url = "https://travelblog.com",
                    AuthorId = authors[1].AuthorId
                }
            };

                context.Blogs.AddRange(blogs);

                var posts = new List<Post>
            {
                new Post
                {
                    PostId = Guid.NewGuid(),
                    BlogId = blogs[0].BlogId,
                    Content = "This is a sample tech blog post content.",
                    Title = "Tech Post 1",
                    DatePublished = DateTime.Now
                },
                new Post
                {
                    PostId = Guid.NewGuid(),
                    BlogId = blogs[0].BlogId,
                    Content = "Another tech blog post for testing.",
                    Title = "Tech Post 2",
                    DatePublished = DateTime.Now
                },
                new Post
                {
                    PostId = Guid.NewGuid(),
                    BlogId = blogs[1].BlogId,
                    Content = "Explore the world through our travel blog.",
                    Title = "Travel Post 1",
                    DatePublished = DateTime.Now
                }
             };

                context.Posts.AddRange(posts);
                context.SaveChanges();
            }
        }
    }
}
