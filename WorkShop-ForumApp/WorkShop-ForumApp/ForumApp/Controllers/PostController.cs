using ForumApp.Contracts;
using ForumApp.Data.Models;
using ForumApp.ViewModels.Post;
using Microsoft.AspNetCore.Mvc;

namespace ForumApp.Controllers
{
    public class PostController : Controller
    {
        private readonly IPostService service;

        public PostController(IPostService service)
        {
            this.service = service;
        }

        public async Task<IActionResult> All()
        {
            var model = await service.AllAsync();

            return View(model);
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(PostFormViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("All", "Post");
            }

            try
            {
                await service.AddPostAsync(model);
            }
            catch (Exception)
            {
                ModelState.AddModelError(string.Empty, "Unexpected error occurred while adding your post!");

                return View(model);
            }

            return RedirectToAction("All", "Post");
        }

        [HttpGet]
        public async Task<IActionResult> Edit(string id)
        {
            try
            {
                PostFormViewModel postModel = await service.EditPostAsync(id);

                return View(postModel);
            }
            catch (Exception)
            {
                return RedirectToAction("All", "Post");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Edit(string id, PostFormViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            try
            {
                await service.EditByIdAsync(id, model);
            }
            catch (Exception)
            {
                ModelState.AddModelError(string.Empty, "Unexpected error occurred while updating your post!");

                return View(model);
            }

            return RedirectToAction("All", "Post");
        }

        [HttpPost]
        public async Task<IActionResult> Delete(string id)
        {
            try
            {
                await service.DeleteByIdAsync(id);
            }
            catch (Exception)
            {

            }

            return RedirectToAction("All", "Post");
        }
    }
}
