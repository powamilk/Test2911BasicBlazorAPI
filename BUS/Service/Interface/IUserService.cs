using BUS.ViewModel.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS.Service.Interface
{
    public interface IUserService
    {
        Task<IEnumerable<UserVM>> GetAllAsync();
        Task<UserVM> GetByIdAsync(int id);
        Task CreateAsync(UserCreateVM userVM);
        Task UpdateAsync(int id, UserUpdateVM userVM);
        Task DeleteAsync(int id);
    }
}
