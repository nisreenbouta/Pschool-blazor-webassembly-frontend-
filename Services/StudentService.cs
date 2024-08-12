using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace PschoolClient.Services
{
    public class StudentService
    {
        private readonly HttpClient _httpClient;

        public StudentService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<Student>> GetStudentsAsync()
        {
            return await _httpClient.GetFromJsonAsync<IEnumerable<Student>>("api/Students");
        }

        public async Task<Student> GetStudentAsync(int id)
        {
            return await _httpClient.GetFromJsonAsync<Student>($"api/Students/{id}");
        }

        public async Task AddStudentAsync(Student student)
        {
            await _httpClient.PostAsJsonAsync("api/Students", student);
        }

        public async Task UpdateStudentAsync(Student student)
        {
            await _httpClient.PutAsJsonAsync($"api/Students/{student.Id}", student);
        }

        public async Task DeleteStudentAsync(int id)
        {
            await _httpClient.DeleteAsync($"api/Students/{id}");
        }

        public class Student
        {
            public int Id { get; set; }
            public string UserName { get; set; }
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public int ParentId { get; set; }
            public bool IsActive { get; set; }
            public DateTime DateOfBirth { get; set; }
            public string Gender { get; set; }
            public string Grade { get; set; }
        }
    }
}
