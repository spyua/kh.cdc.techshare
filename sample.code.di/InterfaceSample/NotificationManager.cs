namespace sample.code.di.InterfaceSample
{
    public class NotificationManager
    {
        private readonly INotificationService _notificationService;

        private const int MaxRetryAttempts = 3;

        public NotificationManager(INotificationService notificationService)
        {
            _notificationService = notificationService;
        }

        public bool Notify(string message)
        {
            // 嘗試發送通知並實現重試機制
            for (int attempt = 1; attempt <= MaxRetryAttempts; attempt++)
            {
                try
                {
                    _notificationService.Send(message);
                    Console.WriteLine($"Notification sent successfully on attempt {attempt}.");
                    return true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Attempt {attempt} failed: {ex.Message}");
                    if (attempt == MaxRetryAttempts)
                    {
                        Console.WriteLine("Max retry attempts reached. Notification failed.");
                        return false;
                    }
                }
            }
            return false;
        }
    }
}
