using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using PschoolClient.Models;

namespace PschoolClient.Services
{
    public class ParentService
    {
        private readonly HttpClient _httpClient;

        public ParentService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<Parent>> GetParentsAsync()
        {
            return await _httpClient.GetFromJsonAsync<List<Parent>>("parents");
        }

        public async Task AddParent(Parent parent)
        {
            var response = await _httpClient.PostAsJsonAsync("parents", parent);
            response.EnsureSuccessStatusCode();
        }

        public async Task DeleteParent(int id)
        {
            var response = await _httpClient.DeleteAsync($"parents/{id}");
            response.EnsureSuccessStatusCode();
        }

    }
}

