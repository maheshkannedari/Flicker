
using Microsoft.EntityFrameworkCore.Migrations.Operations;
using UserService.Entities;

namespace UserService.Respository
{
    public interface IUserRepo
    {
        public bool Insert(User u);
        public bool Validate(User u);
    }
}