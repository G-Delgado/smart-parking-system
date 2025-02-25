using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Testing;
using Xunit;

namespace MyProject.Tests
{
    public class AuthControllerTests : IClassFixture<WebApplicationFactory<Program>>
    {
        private readonly HttpClient _client;

        public AuthControllerTests(WebApplicationFactory<Program> factory)
        {
            _client = factory.CreateClient();
        }

        [Fact]
        public async Task Login_ReturnsToken_WhenValidCredentials()
        {
            var loginRequest = new
            {
                Username = "admin",
                Password = "admin"
            };

            var response = await _client.PostAsJsonAsync("/api/auth/login", loginRequest);

            response.EnsureSuccessStatusCode();
            var token = await response.Content.ReadAsStringAsync();

            Assert.False(string.IsNullOrEmpty(token));
        }

        [Fact]
        public async Task Login_ReturnsUnauthorized_WhenInvalidCredentials()
        {
            var loginRequest = new
            {
                Username = "admin",
                Password = "wrongpassword"
            };

            var response = await _client.PostAsJsonAsync("/api/auth/login", loginRequest);

            Assert.Equal(System.Net.HttpStatusCode.Unauthorized, response.StatusCode);
        }
    }
}
