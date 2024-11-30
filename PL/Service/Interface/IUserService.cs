using BUS.ViewModel.User;

namespace PL.Service.Interface
{
    public interface IUserService
    {
        Task<IEnumerable<UserVM>> GetAllAsync();
        Task<UserVM> GetByIdAsync(int id);
        Task CreateAsync(UserCreateVM userCreateVM);
        Task UpdateAsync(int id, UserUpdateVM userUpdateVM);
        Task DeleteAsync(int id);
    }
}
