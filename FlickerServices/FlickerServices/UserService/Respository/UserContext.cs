using Microsoft.EntityFrameworkCore;
using UserService.Entities;
using Microsoft.Extensions.Options;


namespace UserService.Respository
{
    public class UserContext:DbContext
    {
        public UserContext() { }
        public UserContext(DbContextOptions<UserContext> options) : base(options) { }
        public DbSet<User> Users { get; set; }
    }
}
