namespace sample.code.service.CouplingPractice
{
    public class NotificationManager
    {
        public void Notify(string message)
        {
            EmailNotificationService emailService = new EmailNotificationService();
            emailService.Send(message);
        }
    }
}
