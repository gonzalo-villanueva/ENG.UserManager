using ENG.UserManager.Domain.Entities;
using ENG.UserManager.Domain.Models;

namespace ENG.UserManager.Domain.Interfaces.Services;

public interface IUserService
{
    Task<IEnumerable<User>> GetAllUsers();
    Task<IEnumerable<User>> GetAllActiveUsers();
    Task<User> GetUserById(string id);
    Task<User> CreateUser(UserCreateModel newUser);
    Task<User> UpdateUserData(User newUserValues);
    Task<User> UpdateUserState(string id);
    Task<bool> DeleteUser(string id);
}