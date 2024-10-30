using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sample.code.di.CouplingPractice
{
    internal class EmailNotificationService
    {
        public void Send(string message)
        {
            Console.WriteLine($"Sending email: {message}");
        }
    }
}
