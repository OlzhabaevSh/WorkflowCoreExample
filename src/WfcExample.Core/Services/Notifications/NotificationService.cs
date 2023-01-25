using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WfcExample.Core.Services.Notifications
{
    public class NotificationService
    {
        private readonly INotificationProvider notificationProvider;

        public NotificationService(INotificationProvider notificationProvider)
        {
            this.notificationProvider = notificationProvider;
        }

        public async Task SendWelcome(string receiver) 
        {
            var sender = "system";
            var title = "Welcome to the System";
            var content = "Some important content for users";

            await this.notificationProvider
                .SendNotification(
                    sender, 
                    receiver, 
                    title, 
                    content);
        }

        public async Task SendCode(string receiver, string code) 
        {
            var sender = "system";
            var title = "Registration code";
            var content = code;

            await this.notificationProvider
                .SendNotification(
                    sender,
                    receiver,
                    title,
                    content);
        }
    }
}
