using ENG.UserManager.Domain.Interfaces.Repositories;
using ENG.UserManager.Domain.Interfaces.Services;
using ENG.UserManager.Domain.Entities;
using ENG.UserManager.Domain.Models;

namespace ENG.UserManager.Services;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;

    public UserService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public Task<IEnumerable<User>> GetAllUsers()
    {
        return _userRepository.GetAllUsers();
    }

    public Task<IEnumerable<User>> GetAllActiveUsers()
    {
        return _userRepository.GetAllActiveUsers();
    }

    public Task<User> GetUserById(string id)
    {
        return _userRepository.GetUserById(id);
    }

    public Task<User> CreateUser(UserCreateModel user)
    {
        return _userRepository.CreateUser(user);
    }

    public Task<User> UpdateUserState(string id)
    {
        return _userRepository.UpdateUserState(id);
    }

    public Task<User> UpdateUserData(User user)
    {
        return _userRepository.UpdateUserData(user);
    }

    public Task<bool> DeleteUser(string id)
    {
        return _userRepository.DeleteUser(id);
    }

}
