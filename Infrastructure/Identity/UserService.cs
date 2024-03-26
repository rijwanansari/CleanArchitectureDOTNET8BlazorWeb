using Application.Common.Interface;
using Application.Common.Model;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Identity
{
    public class UserService : IUserService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ICurrentUserService _currentUserService;

        public UserService(UserManager<ApplicationUser> userManager, ICurrentUserService currentUserService)
        {
            _userManager = userManager;
            _currentUserService = currentUserService;
        }

        public async Task<ResponseModel<UserModel>> GetUserByIdAsync(string userId)
        {
            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
            {
                return ResponseModel<UserModel>.FailureResponse("User not found");
            }           
            var usermodel = new UserModel
            {
                UserId = user.Id,
                Email = user.Email,
                PhoneNumber = user.PhoneNumber,
                UserName = user.UserName,
                EmailConfirmed = user.EmailConfirmed
            };
            return ResponseModel<UserModel>.SuccessResponse("User found", usermodel);
        }

        public async Task<ResponseModel<UserModel>> GetUserByEmailAsync(string email)
        {
            var user = await _userManager.FindByEmailAsync(email);
            if (user == null)
            {
                return ResponseModel<UserModel>.FailureResponse("User not found");
            }
            var usermodel = new UserModel
            {
                UserId = user.Id,
                Email = user.Email,
                PhoneNumber = user.PhoneNumber,
                UserName = user.UserName,
                EmailConfirmed = user.EmailConfirmed
            };
            return ResponseModel<UserModel>.SuccessResponse("User found", usermodel);
        }

        public async Task<ResponseModel<List<UserModel>>> GetAllUsers()
        {
            var users = await _userManager.Users.ToListAsync();
            if (users == null)
            {
                return ResponseModel<List<UserModel>>.FailureResponse("User not found");
            }
            return new ResponseModel<List<UserModel>>
            {
                Success = true,
                Output = users.Select(user => new UserModel
                {
                    UserId = user.Id,
                    Email = user.Email,
                    PhoneNumber = user.PhoneNumber,
                    UserName = user.UserName,
                    EmailConfirmed = user.EmailConfirmed
                }).ToList()
            };
        }

        public Task<ResponseModel<UserModel>> GetCurrentUser()
        {
            throw new NotImplementedException();
        }
    }
}
