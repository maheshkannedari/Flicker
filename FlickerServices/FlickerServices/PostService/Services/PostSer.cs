using PostService.Entities;
using PostService.Repository;

namespace PostService.Services
{
    public class PostSer : IPostSer
    {
        private readonly IPostRepository _postRepository;

        public PostSer(IPostRepository postRepository)
        {
            _postRepository = postRepository;
        }

        public bool AddPost(Post post)
        {
            return _postRepository.AddPost(post);
        }

        public async Task<Post> GetPostById(int id)
        {
            return await _postRepository.GetPostById(id);
        }

        public async Task<List<Post>> GetAllPosts()
        {
            return await _postRepository.GetAllPosts();
        }

        public async Task<Post> UpdatePost(Post post)
        {
            return await _postRepository.UpdatePost(post);
        }

        public async Task<Post> DeletePost(int id)
        {
            return await _postRepository.DeletePost(id);
        }
    }
}
