using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories.Interface
{
    public interface IWorkRepo
    {
        Task<IEnumerable<Work>> GetAllAsync();
        Task<Work> GetByIdAsync(int id);
        Task AddAsync(Work work);
        Task UpdateAsync(Work work);
        Task DeleteAsync(int id);
        Task<IEnumerable<Work>> GetByUserIdAsync(int userId);
    }
}
