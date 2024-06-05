using Microsoft.EntityFrameworkCore;
using PeopleApi.data;
using PeopleApi.Interfaces;
using PeopleApi.Models;

namespace PeopleApi.Repository
{
    public class UserRepository : IUser
    {
        private readonly UserContext _context;

        public UserRepository(UserContext context)
        {
            _context = context;
        }

        public async Task<User> CreateUser(User users)
        {
            _context.users.Add(users);
            await _context.SaveChangesAsync();
            return users;
        }

        public async Task<User> DeleteUser(int id)
        {
            var user = await _context.users.FindAsync(id);
            _context.users.Remove(user);
            await _context.SaveChangesAsync();
            return user;
        }

        public async Task<IEnumerable<User>> GetAllUsers()
        {
            return await _context.users.ToListAsync();
        }

        public async Task<User> GetUserById(int? id)
        {
            return await _context.users.FirstOrDefaultAsync(m => m.ID == id);
        }



        public async Task<User> UpdateUser(User users)
        {
            _context.Update(users);
            await _context.SaveChangesAsync();
            return users;
        }
    }
}
