using ChatService.Entities;
using ChatService.Repository;

namespace ChatService.Services
{
    public class ChatSer : IChatSer
    {
        private readonly IChatRepo _chatrepo;

        public ChatSer(IChatRepo chatrepo)
        {
            _chatrepo = chatrepo;
        }

        public bool AddChat(Chat chat)
        {
            return _chatrepo.AddChat(chat);
        }

        public async Task<Chat> GetChatById(int id)
        {
            return await _chatrepo.GetChatById(id);
        }

        public async Task<List<Chat>> GetAllChat()
        {
            return await _chatrepo.GetAllChat();
        }

        public async Task<Chat> UpdateChat(Chat chat)
        {
            return await _chatrepo.UpdateChat(chat);
        }
        public async Task<Chat> DeleteChat(int id)
        {
            return await _chatrepo.DeleteChat(id);
        }

    }
}
