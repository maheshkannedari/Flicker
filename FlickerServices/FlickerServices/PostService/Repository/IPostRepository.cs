using PostService.Entities;

namespace PostService.Repository
{
    public interface IPostRepository
    {
        bool AddPost(Post post);
        Task<Post> DeletePost(int id);
        Task<List<Post>> GetAllPosts();
        Task<Post> GetPostById(int id);
        Task<Post> UpdatePost(Post post);
    }
}