using UserService.Entities;
using UserService.Services;

namespace UserService.Services
{
    public interface IUserSer
    {
        bool AddUser(User u);
        bool ValidateUser(User u);


    }
}