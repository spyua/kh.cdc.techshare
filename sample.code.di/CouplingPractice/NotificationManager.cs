using sample.code.di.CouplingSample;

namespace sample.code.di.CouplingPractice
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
