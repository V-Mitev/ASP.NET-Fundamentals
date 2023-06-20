using ForumApp.ViewModels.Post;

namespace ForumApp.Contracts
{
    public interface IPostService
    {
        public Task<ICollection<PostViewModel>> AllAsync();

        public Task AddPostAsync(PostFormViewModel model);

        public Task<PostFormViewModel> EditPostAsync(string id);

        public Task EditByIdAsync(string id, PostFormViewModel model);

        public Task DeleteByIdAsync(string id);
    }
}
