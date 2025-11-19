using Microsoft.EntityFrameworkCore;

namespace DBWebApp
{

    public class ChatMessage
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Message { get; set; } = null!;
        public DateTime time { get; set; } = DateTime.UtcNow;
    }



    public class AppDBContext : DbContext
    {
        public DbSet<ChatMessage> Messages { get; set; }


        public AppDBContext(DbContextOptions<AppDBContext> options)
            : base(options)
        {

        }

        public async Task AddMessage(MessageDTO dto)
        {
            var message = new ChatMessage
            {
                Message = dto.Message,
                Name = dto.Name
            };

            await Messages.AddAsync(message);
            await SaveChangesAsync();
        }

        public async Task<List<MessageDTO>> GetMessages()
        {
            List<MessageDTO> messages = new List<MessageDTO>();

            foreach (ChatMessage msg in Messages.OrderByDescending(m => m.time))
            {
                messages.Add(new MessageDTO
                {
                    Message = msg.Message,
                    Name = msg.Name
                });
            }

            return messages;
        }
    }
}
