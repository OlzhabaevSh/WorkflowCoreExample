using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WfcExample.Core.Services.Notifications;

namespace Wfc.Providers.LocalProviders
{
    public class ConsoleNotificatonProvider : INotificationProvider
    {
        public Task SendNotification(string sender, string receiver, string title, string content)
        {
            Console.WriteLine($"From: {sender}");
            Console.WriteLine($"To: {receiver}");
            Console.WriteLine($"{title}");
            Console.WriteLine($"{content}");

            return Task.CompletedTask;
        }
    }

    public class NotificationEventArg : EventArgs 
    {
        public string Sender { get; set; }

        public string Receiver { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }
    }
}
