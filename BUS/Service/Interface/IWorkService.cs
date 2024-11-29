using BUS.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS.Service.Interface
{
    public interface IWorkService
    {
        Task<IEnumerable<WorkVM>> GetAllAsync();
        Task<WorkVM> GetByIdAsync(int id);
        Task CreateAsync(WorkCreateVM workVM);
        Task UpdateAsync(WorkUpdateVM workVM);
        Task DeleteAsync(int id);
    }
}
