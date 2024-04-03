using AppDocker.Entities;
using AppDocker.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace AppDocker.Services
{
    public class UserService : IUser
    {
        private readonly AppDBContext _context;

        public UserService(AppDBContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<User>> GetUser()
        {
            return await this._context.Users.ToListAsync();
        }

        public async Task<User> CreateUser(User user)
        {
            this._context.Users.Add(user);
            await this._context.SaveChangesAsync();

            return user;
        }

        public bool ExistUser(string email)
        {
            var userAlreadyExists = this._context.Users.Any(x => x.Email == email);
            if (userAlreadyExists)
            {
                return true;
            }
            return false;
        }

        
    }
}

