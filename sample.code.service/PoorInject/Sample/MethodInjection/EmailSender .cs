using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sample.code.service.PoorInject.Sample.MethodInjection
{
    public class EmailSender : INotificationSender
    {
        public void SendNotification(string message)
        {
            Console.WriteLine($"Sending email notification: {message}");
        }
    }

}
