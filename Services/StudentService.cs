using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using PschoolClient.Models;

namespace PschoolClient.Services
{
    public class StudentService
    {
        private readonly HttpClient _httpClient;

        public StudentService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<Student>> GetStudentsAsync()
        {
            return await _httpClient.GetFromJsonAsync<List<Student>>("students");
        }
    }
}
