using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace PschoolClient.Services
{
    public class ParentService
    {
        private readonly HttpClient _httpClient;

        public ParentService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<Parent>> GetParentsAsync()
        {
            return await _httpClient.GetFromJsonAsync<IEnumerable<Parent>>("api/Parents");
        }

        public async Task<Parent> GetParentAsync(int id)
        {
            return await _httpClient.GetFromJsonAsync<Parent>($"api/Parents/{id}");
        }

        public async Task AddParentAsync(Parent parent)
        {
            await _httpClient.PostAsJsonAsync("api/Parents", parent);
        }

        public async Task UpdateParentAsync(Parent parent)
        {
            await _httpClient.PutAsJsonAsync($"api/Parents/{parent.Id}", parent);
        }

        public async Task DeleteParentAsync(int id)
        {
            await _httpClient.DeleteAsync($"api/Parents/{id}");
        }

        public class Parent
        {
            public int Id { get; set; }
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public string UserName { get; set; }
            public string Email { get; set; }
            public string Phone { get; set; }
            public string WorkPhone { get; set; }
            public string HomePhone { get; set; }
            public string HomeAddress { get; set; }
            public bool IsActive { get; set; }
        }
    }
}
