using UserService.Respository;
using UserService.Entities;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using UserService.Services;


namespace UserService.Services
{
    public class UserSer : IUserSer
    {
        private readonly IUserRepo _repo;
        public UserSer(IUserRepo repo)
        {
            _repo = repo;
        }
        public bool AddUser(User u)
        {
            return _repo.Insert(u);
        }

        public bool ValidateUser(User u)
        {
            return _repo.Validate(u);
        }
    }
}
