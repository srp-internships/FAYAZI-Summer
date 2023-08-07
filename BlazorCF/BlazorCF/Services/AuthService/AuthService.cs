using BlazorCF.Contracts.Requests;
using BlazorCF.Domain;
using static System.Net.WebRequestMethods;
using System.Net.Http.Headers;
using System.Net.Http.Json;

namespace BlazorCF.Services.AuthService
{
    public class AuthService : IAuthService
    {
        private readonly HttpClient _http;
        public AuthService(HttpClient http)
        {
            _http = http;
        }

        public async Task<ServiceResponse<User>> CurrentUserInfo(string token)
        {
            var response = new ServiceResponse<User>();
            _http.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var res = await _http.GetAsync("https://api.github.com/user");
            if (!res.IsSuccessStatusCode)
            {
                response.Success = false;
                return response;
            }
            response.Data = await res.Content.ReadFromJsonAsync<User>();
            return response;
        }
    }
}
