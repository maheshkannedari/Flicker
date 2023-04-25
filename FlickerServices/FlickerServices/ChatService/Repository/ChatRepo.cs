
using Microsoft.EntityFrameworkCore;
using ChatService.Entities;

namespace ChatService.Repository
{
    public class ChatRepo : IChatRepo
    {
        private readonly ChatContext _dbContext;

        public ChatRepo(ChatContext dbContext)
        {
            _dbContext = dbContext;
        }

        public bool AddChat(Chat chat)
        {
            try
            {
                _dbContext.Chats.Add(chat);
                var result = _dbContext.SaveChanges();
                return (result > 0) ? true : false;
            }
            catch { }
            return true;
        }

        public async Task<Chat> GetChatById(int id)
        {
            return await _dbContext.Set<Chat>().FindAsync(id);
        }

        public async Task<List<Chat>> GetAllChat()
        {
            return await _dbContext.Set<Chat>().ToListAsync();
        }

        public async Task<Chat> UpdateChat(Chat chat)
        {
            _dbContext.Entry(chat).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
            return chat;
        }

        public async Task<Chat> DeleteChat(int id)
        {
            var chat = await _dbContext.Set<Chat>().FindAsync(id);
            if (chat == null)
            {
                return null;
            }

            _dbContext.Set<Chat>().Remove(chat);
            await _dbContext.SaveChangesAsync();
            return chat;
        }
    }
}

