namespace sample.code.service.InterfaceSample
{
    public class SMSNotificationService : INotificationService
    {
        public void Send(string message)
        {
            Console.WriteLine($"Sending SMS: {message}");
        }
    }
}
