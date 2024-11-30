using AutoMapper;
using BUS.Service.Interface;
using BUS.ViewModel.User;
using DAL.Entities;
using DAL.Repositories.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS.Service.Implement
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UserService(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }
        public async Task<IEnumerable<UserVM>> GetAllAsync()
        {
            var users = await _userRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<UserVM>>(users);
        }
        public async Task<UserVM> GetByIdAsync(int userId)
        {
            var user = await _userRepository.GetByIdAsync(userId);
            if (user == null) return null;
            return _mapper.Map<UserVM>(user);
        }
        public async Task CreateAsync(UserCreateVM userCreateVM)
        {
            var user = _mapper.Map<User>(userCreateVM);
            await _userRepository.AddAsync(user);
        }
        public async Task UpdateAsync(int userId, UserUpdateVM userUpdateVM)
        {
            var user = await _userRepository.GetByIdAsync(userId);
            if (user != null)
            {
                _mapper.Map(userUpdateVM, user);
                await _userRepository.UpdateAsync(user);
            }
        }
        public async Task DeleteAsync(int userId)
        {
            await _userRepository.DeleteAsync(userId);
        }
    }
}
