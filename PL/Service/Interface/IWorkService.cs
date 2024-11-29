using BUS.ViewModel;

namespace PL.Service.Interface
{
    public interface IWorkService
    {
        Task<IEnumerable<WorkVM>> GetAllAsync();
        Task<WorkVM> GetByIdAsync(int id);
        Task CreateAsync(WorkCreateVM workVM);
        Task UpdateAsync(int id, WorkUpdateVM workVM);
        Task DeleteAsync(int id);
    }
}
