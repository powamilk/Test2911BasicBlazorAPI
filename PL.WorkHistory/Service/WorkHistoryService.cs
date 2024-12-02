using BUS.ViewModel.WorkHistory;

namespace PL.WorkHistory.Service
{
    public class WorkHistoryService : IWorkHistoryService
    {
        private readonly HttpClient _httpClient;

        public WorkHistoryService(HttpClient httpClient)
        {
            _httpClient = httpClient;
            _httpClient.BaseAddress = new Uri("https://localhost:7130/api/");
        }

        public async Task<IEnumerable<WorkHistoryVM>> GetAllAsync()
        {
            try
            {
                var response = await _httpClient.GetAsync("workhistory");

                if (!response.IsSuccessStatusCode)
                {
                    Console.WriteLine($"API lỗi: {response.StatusCode}");
                    return new List<WorkHistoryVM>();
                }

                var workHistories = await response.Content.ReadFromJsonAsync<IEnumerable<WorkHistoryVM>>();
                return workHistories ?? new List<WorkHistoryVM>();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi khi gọi API: {ex.Message}");
                return new List<WorkHistoryVM>();
            }
        }

        public async Task<WorkHistoryVM> GetByIdAsync(int id)
        {
            try
            {
                var response = await _httpClient.GetFromJsonAsync<WorkHistoryVM>($"workhistory/{id}");
                return response;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi khi gọi API: {ex.Message}");
                return null;
            }
        }

        public async Task CreateAsync(WorkHistoryCreateVM workHistoryCreateVM)
        {
            try
            {
                var response = await _httpClient.PostAsJsonAsync("workhistory", workHistoryCreateVM);
                response.EnsureSuccessStatusCode();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi khi tạo WorkHistory: {ex.Message}");
            }
        }

        public async Task UpdateAsync(int id, WorkHistoryUpdateVM workHistoryUpdateVM)
        {
            try
            {
                var response = await _httpClient.PutAsJsonAsync($"workhistory/{id}", workHistoryUpdateVM);
                response.EnsureSuccessStatusCode();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi khi cập nhật WorkHistory: {ex.Message}");
            }
        }

        public async Task DeleteAsync(int id)
        {
            try
            {
                var response = await _httpClient.DeleteAsync($"workhistory/{id}");
                response.EnsureSuccessStatusCode();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi khi xóa WorkHistory: {ex.Message}");
            }
        }
    }
}
