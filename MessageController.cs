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


        [HttpGet("create")]
        public async Task<IActionResult> CreateMessage(string name, string message)
        {
            Console.WriteLine("Created");

            var messageDTO = new MessageDTO
            {
                Name = name,
                Message = message
            };

            await dbContext.AddMessage(messageDTO);
            return Ok(messageDTO);
        }

        [HttpGet("list")]
        public async Task<ActionResult<List<MessageDTO>>> GetMessages()
        {
            Console.WriteLine("Sending list");
            var messages = await dbContext.GetMessages();
            return Ok(messages);
        }

    }
}
