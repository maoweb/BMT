using BMT_API.Models;
using BMT_API.Models.Dto;

namespace BMT_API.Repository.IRepostiory
{
    public interface IUserRepository
    {
        bool IsUniqueUser(string username);
        Task<LoginResponseDTO> Login(LoginRequestDTO loginRequestDTO);
    }
}
