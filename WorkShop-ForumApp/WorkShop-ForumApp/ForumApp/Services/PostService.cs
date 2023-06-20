using ForumApp.Contracts;
using ForumApp.Data;
using ForumApp.Data.Models;
using ForumApp.ViewModels.Post;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ForumApp.Services
{
    public class PostService : IPostService
    {
        private readonly ForumAppDbContext data;

        public PostService(ForumAppDbContext data)
        {
            this.data = data;
        }

        public async Task AddPostAsync(PostFormViewModel model)
        {
            Post newPost = new Post()
            {
                Title = model.Title,
                Content = model.Content
            };

            await data.Posts.AddAsync(newPost);
            await data.SaveChangesAsync();
        }

        public async Task<ICollection<PostViewModel>> AllAsync()
        {
            return await data.Posts
                .Select(p => new PostViewModel
                {
                    Id = p.Id.ToString(),
                    Title = p.Title,
                    Content = p.Content
                })
                .ToListAsync();
        }

        public async Task<PostFormViewModel> EditPostAsync(string id)
        {
            var postToEdit = await data.Posts
                .FirstAsync(p => p.Id.ToString() == id);

            return new PostFormViewModel
            {
                Title = postToEdit.Title,
                Content = postToEdit.Content
            };
        }

        public async Task EditByIdAsync(string id, PostFormViewModel postEditedModel)
        {
            Post postToEdit = await data
                .Posts
                .FirstAsync(p => p.Id.ToString() == id);

            postToEdit.Title = postEditedModel.Title;
            postToEdit.Content = postEditedModel.Content;

            await data.SaveChangesAsync();
        }

        public async Task DeleteByIdAsync(string id)
        {
            Post postToDelete = await data.Posts
                .FirstAsync(p => p.Id.ToString() == id);

            data.Posts.Remove(postToDelete);
            await data.SaveChangesAsync();
        }
    }
}
