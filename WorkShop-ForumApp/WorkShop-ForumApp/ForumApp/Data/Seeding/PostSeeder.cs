using ForumApp.Data.Models;

namespace ForumApp.Data.Seeding
{
    public class PostSeeder
    {
        public ICollection<Post> GeneretePosts()
        {
            ICollection<Post> posts = new HashSet<Post>();

            Post post;

            post = new Post()
            {
                Title = "My first Post",
                Content = "My first post will be about performing CRUD operations in MVC. It's so much fun!"
            };
            posts.Add(post);

            post = new Post()
            {
                Title = "My second post",
                Content = "This is my second post. CRUD operations in MVC are getting more and more interesting!"
            };
            posts.Add(post);

            post = new Post()
            {
                Title = "My third post",
                Content = "Hello there! I'm getting better and better with the CRUD operations in MVC. Stay tunned!"
            };
            posts.Add(post);

            return posts;
        }
    }
}
