using Microsoft.AspNetCore.Mvc;

namespace DBWebApp
{
    [ApiController]
    [Route("[controller]")]
    public class MessageController : ControllerBase
    {
        private AppDBContext dbContext;
        public MessageController(AppDBContext context)
        {
            dbContext = context;
        }


        [HttpPost("create")]
        public async Task<IActionResult> CreateMessage([FromBody] MessageDTO messageDTO)
        {
            await dbContext.AddMessage(messageDTO);
            return Ok(messageDTO);
        }

        [HttpGet("list")]
        public async Task<ActionResult<List<MessageDTO>>> GetMessages()
        {
            var messages = await dbContext.GetMessages();
            return Ok(messages);
        }

    }
}
