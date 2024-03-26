using Application.Common.Model;

namespace Application.Common.Interface
{
    public interface IUserService
    {
        Task<ResponseModel<UserModel>> GetUserByIdAsync(string userId);
        Task<ResponseModel<UserModel>> GetUserByEmailAsync(string email);
        Task<ResponseModel<List<UserModel>>> GetAllUsers();
        Task<ResponseModel<UserModel>> GetCurrentUser();
    }
}
