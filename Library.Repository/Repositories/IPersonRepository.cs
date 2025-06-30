using Library.ViewModel.ViewModels;

namespace Library.Repository.Repositories
{
    public interface IPersonRepository
    {
        Task<List<PersonVm>> GetAll();
        Task<PersonVm?> FindById(int personId);
        Task<bool> Add(PersonCreateVm personCreateVm);
        Task<bool> Edit(PersonEditVm personEditVm);
        Task<bool> Delete(int personId);

    }
}
