using Library.Contracts;
using Library.Models.Book;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Library.Controllers
{
    [Authorize]
    public class BookController : Controller
    {
        private readonly IBookService bookService;

        public BookController(IBookService bookService)
        {
            this.bookService = bookService;
        }

        public async Task<IActionResult> All()
        {
            var allBooks =  await bookService.GetAllBooksAsync();

            return View(allBooks);
        }

        public async Task<IActionResult> Mine()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            var mineBooks = await bookService.GetAllMineBooksAsync(userId);

            return View(mineBooks);
        }

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            AddBookViewModel model = await bookService.GetAllCategoriesAsync();

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddBookViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            await bookService.AddBookAsync(model);

            return RedirectToAction("All","Book");
        }

        public async Task<IActionResult> AddToCollection(BookViewModel model)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            await bookService.AddToCollectionAsyc(userId, model);

            return RedirectToAction("All", "Book");
        }

        public async Task<IActionResult> RemoveFromCollection(BookViewModel model)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            await bookService.RemoveFromCollectionAsync(userId, model);

            return RedirectToAction("Mine", "Book");
        }
    }
}
