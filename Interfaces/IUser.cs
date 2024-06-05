using PeopleApi.Models;

namespace PeopleApi.Interfaces
{
    public interface IUser
    {
        Task<User> CreateUser(User user);
        Task<IEnumerable<User>> GetAllUsers();
        Task<User> GetUserById(int? id);
        Task<User> UpdateUser(User user);
        Task<User> DeleteUser(int id);
    }
}
