namespace ExpressMs.Messages
{
    public interface IWhatsAppMessageSender
    {
        public void SendTextMessage(string reciever ,string textmessage);
        public void SendMultimediaMesssage(string reciever, string Url,string messageBody);
    }
}
