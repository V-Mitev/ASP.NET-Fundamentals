using ForumApp.Data;
using ForumApp.Data.Models;
using ForumApp.ViewModels.Post;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ForumApp.Controllers
{
    public class PostController : Controller
    {
        private readonly ForumAppDbContext data;

        public PostController(ForumAppDbContext data)
        {
            this.data = data;
        }

        public async Task<IActionResult> All()
        {
            var posts = await data.Posts
                .Select(p => new PostViewModel()
                {
                    Id = p.Id.ToString(),
                    Title = p.Title,
                    Content = p.Content
                })
                .ToListAsync();

            return View(posts);
        }

        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(PostFormViewModel model)
        {
            var post = new Post()
            {
                Title = model.Title,
                Content = model.Content
            };

            await data.Posts.AddAsync(post);
            await data.SaveChangesAsync();

            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Edit(string id)
        {
            var post = await data.Posts.FirstAsync(p => p.Id.ToString() == id);

            return View(new PostFormViewModel()
            {
                Title = post.Title,
                Content = post.Content
            });
        }

        [HttpPost]
        public async Task<IActionResult> Edit(string id, PostFormViewModel model)
        {
            var post = await data.Posts.FirstAsync(p => p.Id.ToString() == id);

            post.Title = model.Title;
            post.Content = model.Content;

            await data.SaveChangesAsync();

            return RedirectToAction("All", "Post");
        }

        [HttpPost]
        public async Task<IActionResult> Delete(string id)
        {
            var post = await data.Posts.FirstAsync(p => p.Id.ToString() == id);

            data.Posts.Remove(post);

            await data.SaveChangesAsync();

            return RedirectToAction("All", "Post");
        }
    }
}
