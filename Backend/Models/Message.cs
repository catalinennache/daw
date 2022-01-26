namespace Chatty.Models
{
    public class Message:BaseEntity
    {
        public int Sender { get; set; }
        public int Receiver { get; set; }

    }

}