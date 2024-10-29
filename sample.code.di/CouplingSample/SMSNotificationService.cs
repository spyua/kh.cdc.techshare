namespace sample.code.di.CouplingSample
{
    public class SMSNotificationService
    {
        public void Send(string message)
        {
            Console.WriteLine($"Sending SMS: {message}");
        }
    }
}
