// See https://aka.ms/new-console-template for more information

using sample.code.di.InterfaceSample;


/*
NotificationManager manager = new NotificationManager();
manager.Notify(NotificationType.Email, "這是一封測試郵件通知");
manager.Notify(NotificationType.SMS, "這是一則測試SMS通知");
*/

INotificationService message = new EmailNotificationService();
message.Send("這是一則測試SMS通知");