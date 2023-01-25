using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WfcExample.Core.Services.Notifications
{
    public interface INotificationProvider
    {
        Task SendNotification(string sender, string receiver, string title, string content);
    }
}
