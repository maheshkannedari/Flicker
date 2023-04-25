using System.ComponentModel.DataAnnotations;

namespace ChatService.Entities
{
    public class Chat
    {
        
        public int Id { get; set; }
        public string SenderMail { get; set; }
        public string ReceiverMail { get; set; }
        public decimal OfferPrice { get; set; }
        public DateTime Date { get; set; }
    }
  
}
