namespace SocialType.Services
{
    public delegate void SendEmail<T>(T value);
    public class SendActivationLink<T>
    {
        public event SendEmail<T> SendEmailEventHandler;

        public void SendEmailToTheUser(T value)
        {
           
            if (SendEmailEventHandler != null)
            {
                SendEmailEventHandler(value);
            }
        }
    }
}