using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories.Interface
{
    public interface IWorkHistoryRepository
    {
        Task<IEnumerable<WorkHistory>> GetAllAsync();
        Task<WorkHistory> GetByIdAsync(int id);
        Task AddAsync(WorkHistory workHistory);
        Task UpdateAsync(WorkHistory workHistory);
        Task DeleteAsync(int id);
    }
}
