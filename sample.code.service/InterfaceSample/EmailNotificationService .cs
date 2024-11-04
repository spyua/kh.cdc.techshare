namespace sample.code.service.InterfaceSample
{
    public class EmailNotificationService : INotificationService
    {
        public void Send(string message)
        {
            Console.WriteLine($"Sending email: {message}");
        }
    }

}
