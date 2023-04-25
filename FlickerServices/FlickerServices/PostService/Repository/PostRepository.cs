using Microsoft.EntityFrameworkCore;
using PostService.Entities;

namespace PostService.Repository
{
    public class PostRepository : IPostRepository
    {
        private readonly PostContext _dbContext;

        public PostRepository(PostContext dbContext)
        {
            _dbContext = dbContext;
        }

        public bool AddPost(Post post)
        {
            _dbContext.Posts.Add (post);
             var result =_dbContext.SaveChanges();
            return (result>0)?true:false;
        }

        public async Task<Post> GetPostById(int id)
        {
            return await _dbContext.Set<Post>().FindAsync(id);
        }

        public async Task<List<Post>> GetAllPosts()
        {
            return await _dbContext.Set<Post>().ToListAsync();
        }

        public async Task<Post> UpdatePost(Post post)
        {
            _dbContext.Entry(post).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
            return post;
        }

        public async Task<Post> DeletePost(int id)
        {
            var post = await _dbContext.Set<Post>().FindAsync(id);
            if (post == null)
            {
                return null;
            }

            _dbContext.Set<Post>().Remove(post);
            await _dbContext.SaveChangesAsync();
            return post;
        }
    }
}
