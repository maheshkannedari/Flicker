using PostService.Entities;

namespace PostService.Services
{
    public interface IPostSer
    {
        bool AddPost(Post post);
        Task<Post> DeletePost(int id);
        Task<List<Post>> GetAllPosts();
        Task<Post> GetPostById(int id);
        Task<Post> UpdatePost(Post post);
    }
}