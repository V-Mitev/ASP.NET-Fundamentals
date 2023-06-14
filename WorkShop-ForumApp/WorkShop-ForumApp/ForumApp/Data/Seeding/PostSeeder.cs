using ForumApp.Data.Models;

namespace ForumApp.Data.Seeding
{
    public class PostSeeder
    {
        public Post[] GeneratePosts()
        {
            ICollection<Post> posts = new HashSet<Post>();

            Post post;

            post = new Post()
            {
                Title = "My first post",
                Content = 
                "My first post will be about performing CRUD operations in MVC. It's so much fun!"
            };
            posts.Add(post);

            post = new Post()
            {
                Title = "My second post",
                Content =
                "This is my second post. CRUD operations in MVC. It's so much fun!"
            };
            posts.Add(post);

            post = new Post()
            {
                Title = "My first post",
                Content =
                "This is my third post. CRUD operations in MVC. It's so much fun!"
            };
            posts.Add(post);

            return posts.ToArray();
        }
    }
}
