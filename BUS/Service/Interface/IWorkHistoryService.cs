using BUS.ViewModel.WorkHistory;
using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS.Service.Interface
{
    public interface IWorkHistoryService
    {
        Task<IEnumerable<WorkHistoryVM>> GetAllAsync();
        Task<WorkHistoryVM> GetByIdAsync(int id);
        Task AddAsync(WorkHistoryCreateVM workHistoryCreateVM);
        Task UpdateAsync(int id, WorkHistoryUpdateVM workHistoryUpdateVM);
        Task DeleteAsync(int id);
    }
}
