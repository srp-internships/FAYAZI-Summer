using BlazorCF.Contracts.Requests;
using BlazorCF.Domain;

namespace BlazorCF.Services.AuthService
{
    public interface IAuthService
    {
        Task<ServiceResponse<User>> CurrentUserInfo(string token);
    }
}
