using PaintSystemAPIVersionOne.Extension;
using PaintSystemAPIVersionOne.Model;
using PaintSystemAPIVersionOne.Repositories;

namespace PaintSystemAPIVersionOne.Services;

public class UserService
{
    private readonly UserRepository _userRepository;

    public UserService(UserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    /// <summary>
    ///ger all users from _userRepository
    /// </summary>
    /// <returns>list of users </returns>
    public async Task<ServiceResponse<List<User>>> GetAllUsers()
    {
        var users = await _userRepository.GetAllUsers();
        
        
        if (users == null || users.Count == 0)
        {
            // 数据为空，业务返回失败
            return new ServiceResponse<List<User>>(false, "No users found", null);
        }
        // 数据存在，业务返回成功
        return new ServiceResponse<List<User>>(true, "Users retrieved successfully", users);
    }
    
    
    
}