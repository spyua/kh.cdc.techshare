using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sample.code.service.PoorInject.Sample.MethodInjection
{
    // EmailService 只在 sendEmail 方法中需要 INotificationSender
    public class EmailService
    {
        public void SendEmail(string message, INotificationSender sender)
        {
            sender.SendNotification(message);
            Console.WriteLine("Email sent.");
        }

        /*
         public class Program
        {
            public static void Main(string[] args)
            {
                INotificationSender sender = new EmailSender();
                EmailService emailService = new EmailService();

                emailService.SendEmail("Hello, Spyua!", sender);
            }
        }
         
         
         */
    }
}
