using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PostService.Entities;
using PostService.Filters;
using PostService.Services;
using Serilog;
using ILogger = Microsoft.Extensions.Logging.ILogger;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PostService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    /*[Authorize]*/
    [PostException]
    [PostActions]

    public class PostController : ControllerBase
    {
        private readonly IPostSer _post;
        ILogger log;

        public PostController(IPostSer postService, ILogger<PostController> logger)
        {
            _post = postService;
            log = logger;
            log.LogInformation("User Added");
        }

        // GET: api/Post
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Post>>> GetAllPosts()
        {
            var posts = await _post.GetAllPosts();
            return Ok(posts);
        }

        // GET: api/Post/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Post>> GetPostById(int id)
        {
            var post = await _post.GetPostById(id);
            if (post == null)
            {
                return NotFound();
            }

            return Ok(post);
        }

        // POST: api/Post
        [HttpPost]
        public ActionResult AddPost(Post post)
        {
            if(_post.AddPost(post))
            return new OkObjectResult("success");
            return new BadRequestObjectResult("error");
        }

        // PUT: api/Post/5
        [HttpPut("{id}")]
        public async Task<ActionResult<Post>> UpdatePost(int id, Post post)
        {
            if (id != post.id)
            {
                return BadRequest();
            }

            var updatedPost = await _post.UpdatePost(post);
            if (updatedPost == null)
            {
                return NotFound();
            }

            return Ok(updatedPost);
        }

        // DELETE: api/Post/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Post>> DeletePost(int id)
        {
            var deletedPost = await _post.DeletePost(id);
            if (deletedPost == null)
            {
                return NotFound();
            }

            return Ok(deletedPost);
        }
    }
}
