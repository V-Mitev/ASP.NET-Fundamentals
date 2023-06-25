using Library.Models.Book;

namespace Library.Contracts
{
    public interface IBookService
    {
        public Task<ICollection<BookViewModel>> GetAllBooksAsync();

        public Task<ICollection<BookViewModel>> GetAllMineBooksAsync(string userId);

        public Task<AddBookViewModel> GetAllCategoriesAsync();

        public Task AddBookAsync(AddBookViewModel bookViewModel);

        public Task AddToCollectionAsyc(string userId, BookViewModel model);

        public Task RemoveFromCollectionAsync(string userId, BookViewModel model);
    }
}
