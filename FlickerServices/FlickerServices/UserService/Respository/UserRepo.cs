using UserService.Entities;
using UserService.Controllers;
using Microsoft.EntityFrameworkCore;
using UserService.Services;
using System.Reflection.Metadata.Ecma335;

namespace UserService.Respository
{
    public class UserRepo : IUserRepo
    {
        private readonly UserContext _Userdata;
        public UserRepo(UserContext userdata)
        {
            _Userdata = userdata;
        }
        public bool Insert(User u)
        {
            try
            {
                _Userdata.Users.Add(u);
                _Userdata.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }

        }

        public bool Validate(User u) 
        {
            /*User f = _Userdata.Users.FirstOrDefault(uu=>uu.Email==u.Email);*/
            User f = _Userdata.Users.Where(uu=>uu.email==u.email).FirstOrDefault();
            if (f!=null)
            {
                if(f.password==u.password) 
                {
                    return true;
                }
            }
            return false;
        }
    }
}
