namespace sample.code.service.CouplingSample
{

    public enum NotificationType
    {
        Email,
        SMS
    }

    public class NotificationManager
    {
        public void Notify(NotificationType type, string message)
        {
            if (type == NotificationType.Email)
            {
                EmailNotificationService emailService = new EmailNotificationService();
                emailService.Send(message);
            }
            else if (type == NotificationType.SMS)
            {
                SMSNotificationService smsService = new SMSNotificationService();
                smsService.Send(message);
            }
        }
    }
}
