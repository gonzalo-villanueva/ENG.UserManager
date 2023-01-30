using AutoMapper;
using MongoDB.Driver;
using ENG.UserManager.Domain.Entities;
using ENG.UserManager.Domain.Interfaces.Repositories;
using ENG.UserManager.Domain.Models;
using ENG.UserManager.Services;

namespace ENG.UserManager.Application.Handlers;

public class UserRepository : IUserRepository
{
    private readonly MongoDBService _mongoDBService;
    private readonly IMapper _mapper;

    public UserRepository(MongoDBService mongoDBService, IMapper mapper)
    {
        _mongoDBService = mongoDBService;
        _mapper = mapper;
    }

    public async Task<IEnumerable<User>> GetAllUsers()
    {
        return await _mongoDBService.UserCollection.Find(user=>true).ToListAsync();
    }

    public async Task<IEnumerable<User>> GetAllActiveUsers()
    {
        return await _mongoDBService.UserCollection.Find(user => user.Active == true).ToListAsync();
    }

    public async Task<User> GetUserById(string id)
    {
        return await _mongoDBService.UserCollection.Find(user => user.Id == id).FirstOrDefaultAsync();
    }

    public async Task<User> CreateUser(UserCreateModel newUser)
    {
        var user = _mapper.Map<User>(newUser);
        await _mongoDBService.UserCollection.InsertOneAsync(user);
        return user;
    }

    public async Task<User> UpdateUserData(User newUserValues)
    {
        var user = await _mongoDBService.UserCollection.Find(user => user.Id == newUserValues.Id).FirstOrDefaultAsync();
        if (user == null) return null;
        await _mongoDBService.UserCollection.ReplaceOneAsync(user => user.Id == newUserValues.Id, newUserValues);
        return newUserValues;
    }
    public async Task<User> UpdateUserState(string id)
    {
        var user = await _mongoDBService.UserCollection.Find(user => user.Id == id).FirstOrDefaultAsync();
        if (user == null) return null;
        user.Active = !user.Active;
        await _mongoDBService.UserCollection.ReplaceOneAsync(user => user.Id == id, user);
        return user;
    }

    public async Task<bool> DeleteUser(string id)
    {
        var deleteResult = await _mongoDBService.UserCollection.DeleteOneAsync(user => user.Id == id);
        return deleteResult.IsAcknowledged && deleteResult.DeletedCount > 0;
    }
}