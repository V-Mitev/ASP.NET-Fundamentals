using Library.Contracts;
using Library.Data;
using Library.Data.Models;
using Library.Models.Book;
using Microsoft.EntityFrameworkCore;

namespace Library.Services
{
    public class BookService : IBookService
    {
        private readonly LibraryDbContext dbContext;

        public BookService(LibraryDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task AddBookAsync(AddBookViewModel model)
        {
            var book = new Data.Models.Book
            {
                Title = model.Title,
                Author = model.Author,
                ImageUrl = model.Url,
                Description = model.Description,
                CategoryId = model.CategoryId,
                Rating = model.Rating
            };

            await dbContext.Books.AddAsync(book);
            await dbContext.SaveChangesAsync();
        }

        public async Task AddToCollectionAsyc(string userId, BookViewModel book)
        {
            bool alreadyAdded = await dbContext.IdentityUserBooks
                .AnyAsync(ub => ub.CollectorId == userId && ub.BookId == book.Id);

            if (!alreadyAdded)
            {
                var userBook = new IdentityUserBook
                {
                    CollectorId = userId,
                    BookId = book.Id
                };

                await dbContext.IdentityUserBooks.AddAsync(userBook);
                await dbContext.SaveChangesAsync();
            }
        }

        public async Task<ICollection<BookViewModel>> GetAllBooksAsync()
        {
            return await dbContext.Books
                 .Select(b => new BookViewModel()
                 {
                     Id = b.Id,
                     Title = b.Title,
                     Author = b.Author,
                     ImageUrl = b.ImageUrl,
                     Category = b.Category.Name,
                     Rating = b.Rating
                 })
                 .ToListAsync();
        }

        public async Task<AddBookViewModel> GetAllCategoriesAsync()
        {
            var categories = await dbContext.Categories
                .Select(c => new CategoryViewModel()
                {
                    Id = c.Id,
                    Name = c.Name
                })
                .ToListAsync();

            var model = new AddBookViewModel
            {
                Categories = categories
            };

            return model;
        }

        public async Task<ICollection<BookViewModel>> GetAllMineBooksAsync(string userId)
        {
            var books = await dbContext.IdentityUserBooks
                .Where(ub => ub.CollectorId == userId)
                .Select(b => new BookViewModel()
                {
                    Id = b.Book.Id,
                    Title = b.Book.Title,
                    Author = b.Book.Author,
                    ImageUrl = b.Book.ImageUrl,
                    Category = b.Book.Category.Name,
                    Rating = b.Book.Rating,
                    Description = b.Book.Description
                }).ToListAsync();

            return books;
        }

        public async Task RemoveFromCollectionAsync(string userId, BookViewModel book)
        {
            var bookToRemove = await dbContext.IdentityUserBooks
                .Where(ub => ub.CollectorId == userId && ub.BookId == book.Id)
                .FirstOrDefaultAsync();

            if (bookToRemove != null)
            {
                dbContext.IdentityUserBooks.Remove(bookToRemove);
                await dbContext.SaveChangesAsync();
            }
        }
    }
}
