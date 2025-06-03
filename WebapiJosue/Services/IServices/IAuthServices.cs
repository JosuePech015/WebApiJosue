using Domain.DTO;

namespace WebapiJosue.Services.IServices
{
    public interface IAuthServices
    {
        Task<string> Login(LoginRequest request);
    }
}