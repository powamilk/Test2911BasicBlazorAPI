using BUS.ViewModel.WorkHistory;

namespace PL.WorkHistory.Service
{
    public interface IWorkHistoryService
    {
        Task<IEnumerable<WorkHistoryVM>> GetAllAsync();
        Task<WorkHistoryVM> GetByIdAsync(int id);
        Task CreateAsync(WorkHistoryCreateVM workHistoryCreateVM);
        Task UpdateAsync(int id, WorkHistoryUpdateVM workHistoryUpdateVM);
        Task DeleteAsync(int id);
    }
}
