using AppDocker.Entities;

namespace AppDocker.Services.Interfaces
{
    public interface IUser
    {
        Task<IEnumerable<User>> GetUser();
        Task<User> CreateUser(User user);
        bool ExistUser(string email);
    }
}
