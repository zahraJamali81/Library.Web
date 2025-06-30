using Library.ViewModel.ViewModels;

namespace Library.Repository.Repositories
{
    public interface IBookRepository
    {
        Task<List<BookVm>> GetAll();
        Task<BookVm?> FindById(int bookId);
        Task<bool> Add(BookCreeateVm bookCreeateVm);
        Task<bool> Edit(BookEditVm bookEditVm);
        Task<bool> Delete(int bookId);
    }
}


