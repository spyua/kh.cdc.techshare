namespace sample.code.di.CouplingSample
{
    public class EmailNotificationService
    {
        public void Send(string message)
        {
            Console.WriteLine($"Sending email: {message}");
        }
    }
}
