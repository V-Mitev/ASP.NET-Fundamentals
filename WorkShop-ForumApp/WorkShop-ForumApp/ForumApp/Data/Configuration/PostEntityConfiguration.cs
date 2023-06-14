using ForumApp.Data.Models;
using ForumApp.Data.Seeding;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ForumApp.Data.Configuration
{
    public class PostEntityConfiguration : IEntityTypeConfiguration<Post>
    {
        private readonly PostSeeder posts;

        public PostEntityConfiguration()
        {
            posts = new PostSeeder();
        }

        public void Configure(EntityTypeBuilder<Post> builder)
        {
            builder
                .HasData(posts.GeneratePosts());
        }
    }
}
