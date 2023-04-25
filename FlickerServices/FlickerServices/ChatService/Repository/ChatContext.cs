using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using ChatService.Services;
using ChatService.Entities;

namespace ChatService.Repository
{
    public class ChatContext:DbContext
    {
        public ChatContext() { }
        public ChatContext(DbContextOptions<ChatContext> options) : base(options) { }
        public DbSet<Chat> Chats { get; set; }
    }
}


