using BUS.ViewModel.User;
using PL.Service.Interface;

namespace PL.Service.Implement
{
    public class UserService : IUserService
    {
        private readonly HttpClient _httpClient;

        public UserService(HttpClient httpClient)
        {
            _httpClient = httpClient;
            _httpClient.BaseAddress = new Uri("https://localhost:7130/api/");
        }

        public async Task<IEnumerable<UserVM>> GetAllAsync()
        {
            try
            {
                var response = await _httpClient.GetAsync("users");

                if (!response.IsSuccessStatusCode)
                {
                    Console.WriteLine($"API lỗi: {response.StatusCode}");
                    return new List<UserVM>();
                }

                var users = await response.Content.ReadFromJsonAsync<IEnumerable<UserVM>>();
                return users ?? new List<UserVM>();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi khi gọi API: {ex.Message}");
                return new List<UserVM>();
            }
        }

        public async Task<UserVM> GetByIdAsync(int id)
        {
            try
            {
                var response = await _httpClient.GetFromJsonAsync<UserVM>($"users/{id}");
                return response;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi khi gọi API: {ex.Message}");
                return null;
            }
        }

        public async Task CreateAsync(UserCreateVM userCreateVM)
        {
            try
            {
                var response = await _httpClient.PostAsJsonAsync("users", userCreateVM);
                response.EnsureSuccessStatusCode();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi khi tạo người dùng: {ex.Message}");
            }
        }

        public async Task UpdateAsync(int id, UserUpdateVM userUpdateVM)
        {
            try
            {
                var response = await _httpClient.PutAsJsonAsync($"users/{id}", userUpdateVM);
                response.EnsureSuccessStatusCode();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi khi cập nhật người dùng: {ex.Message}");
            }
        }

        public async Task DeleteAsync(int id)
        {
            try
            {
                var response = await _httpClient.DeleteAsync($"users/{id}");
                response.EnsureSuccessStatusCode();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi khi xóa người dùng: {ex.Message}");
            }
        }
    }
}
