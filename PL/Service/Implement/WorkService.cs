
using Microsoft.AspNetCore.Components.Forms;
using PL.Service.Interface;
using BUS.ViewModel;
using System.Net.Http.Headers;
using System.Net.Http.Json;

namespace PL.Service.Implement
{
    public class WorkService : IWorkService
    {
        private readonly HttpClient _httpClient;

        public WorkService(HttpClient httpClient)
        {
            _httpClient = httpClient;
            _httpClient.BaseAddress = new Uri("https://localhost:7130/api/");
        }
        public async Task CreateAsync(WorkCreateVM workVM)
        {
            await _httpClient.PostAsJsonAsync("works", workVM);
        }

        public async Task DeleteAsync(int id)
        {
            await _httpClient.DeleteAsync($"works/{id}");
        }

        public async Task<IEnumerable<WorkVM>> GetAllAsync()
        {
            try
            {
                var response = await _httpClient.GetAsync("works");
                if (!response.IsSuccessStatusCode)
                {
                    Console.WriteLine($"Apii lõi : {response.StatusCode}");
                    return new List<WorkVM>();
                }
                var works = await response.Content.ReadFromJsonAsync<IEnumerable<WorkVM>>();
                return works ?? new List<WorkVM>();
            }
            catch (HttpRequestException httpex)
            {
                Console.WriteLine(httpex.Message);
                return new List<WorkVM>();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return new List<WorkVM>();
            }
        }

        public async Task<WorkVM> GetByIdAsync(int id)
        {
            return await _httpClient.GetFromJsonAsync<WorkVM>($"works/{id}");
        }

        public async Task UpdateAsync(int id, WorkUpdateVM workVM)
        {
            await _httpClient.PutAsJsonAsync($"works/{id}", workVM);
        }

        public async Task<string> UploadImageAsync(IBrowserFile file)
        {
            try
            {
                var formData = new MultipartFormDataContent();
                var fileContent = new StreamContent(file.OpenReadStream(maxAllowedSize: 10 * 1024 * 1024));
                fileContent.Headers.ContentType = new MediaTypeHeaderValue(file.ContentType);

                formData.Add(fileContent, "file", file.Name);

                var response = await _httpClient.PostAsync("work/upload", formData);

                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadFromJsonAsync<dynamic>();
                    return result?.FilePath;
                }
                else
                {
                    throw new Exception("Lỗi khi tải ảnh lên.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi khi upload ảnh: {ex.Message}");
                throw;
            }
        }
    }
}
