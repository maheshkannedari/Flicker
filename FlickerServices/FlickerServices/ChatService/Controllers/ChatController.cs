using ChatService.Entities;
using ChatService.Filters;
using ChatService.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Serilog;
using ILogger = Microsoft.Extensions.Logging.ILogger;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ChatService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    /*[Authorize]*/
    [ChatException]
    [ChatActions]
    public class ChatController : ControllerBase
    {
        private readonly IChatSer _chat;
        ILogger log;
        public ChatController (IChatSer chat, ILogger<ChatController> logger)
        {
            _chat= chat;
            log = logger;
            log.LogInformation("Chat Added");
        }
        // GET: api/<ChatController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Chat>>> GetAllChat()
        {
            var chats = await _chat.GetAllChat();
            return Ok("Message Added");
        }


        // GET api/<ChatController>/5
        [HttpGet("{id}")]

        public async Task<ActionResult<Chat>> GetChatById(int id)
        {
            var chat = await _chat.GetChatById(id);
            if (chat == null)
            {
                return NotFound();
            }

            return Ok(chat);
        }


        // POST api/<ChatController>
        [HttpPost]
        public ActionResult AddChat(Chat chat)
        {
            if (_chat.AddChat(chat))
                return new OkObjectResult("success");
            return new BadRequestObjectResult("error");
        }


        // PUT api/<ChatController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult<Chat>> UpdateChat(int id, Chat chat)
        {
           /*if (id != chat.Id
            {
                return BadRequest();
            }*/

            var updateChat = await _chat.UpdateChat(chat);
            if (updateChat == null)
            {
                return NotFound();
            }

            return Ok(updateChat);
        }


        // DELETE api/<ChatController>/5
        [HttpDelete("{id}")]

        public async Task<ActionResult<Chat>> DeleteChat(int id)
        {
            var deleteChat = await _chat.DeleteChat(id);
            if (deleteChat == null)
            {
                return NotFound();
            }

            return Ok(deleteChat);
        }

    }
}
