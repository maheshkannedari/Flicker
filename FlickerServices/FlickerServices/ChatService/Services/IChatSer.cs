using ChatService.Entities;

namespace ChatService.Services
{
    public interface IChatSer
    {
        bool AddChat(Chat chat);
        Task<Chat> DeleteChat(int id);
        Task<List<Chat>> GetAllChat();
        Task<Chat> GetChatById(int id);
        Task<Chat> UpdateChat(Chat chat);
    }
}