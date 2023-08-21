using BMT_Web.Models.Dto;

namespace BMT_Web.Services.IServices
{
    public interface IAuthService
    {
        Task<T> LoginAsync<T>(LoginRequestDTO objToCreate);
    }
}
