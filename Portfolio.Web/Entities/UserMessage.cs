namespace Portfolio.Web.Entities
{
    public class UserMessage
    {
        public int UserMessageId { get; set; }
        public string Name { get; set; }
        public string Subject { get; set; }
        public string Email { get; set; }
        public string MessageDetail { get; set; }
        public DateTime SendDate { get; set; }
        public bool IsRead { get; set; }
  
    }
}
