using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WfcExample.Core.Services.Notifications;
using WorkflowCore.Interface;
using WorkflowCore.Models;

namespace Wfc.Domains.Workflows.Registrations.Steps
{
    public class SendWelcomeNotificationStepAsync : StepBodyAsync
    {
        public SendWelcomeNotificationStepInputModel Input { get; set; } = new SendWelcomeNotificationStepInputModel();

        public SendWelcomeNotificationStepOutputModel Output { get; set; } = new SendWelcomeNotificationStepOutputModel();

        private readonly NotificationService service;

        public SendWelcomeNotificationStepAsync(NotificationService service)
        {
            this.service = service;
        }

        public override async Task<ExecutionResult> RunAsync(IStepExecutionContext context)
        {
            await this.service.SendWelcome(this.Input.UserName);

            this.Output.IsSent = true;

            return ExecutionResult.Next();
        }
    }

    public class SendWelcomeNotificationStepInputModel 
    {
        public string UserName { get; set; }
    }

    public class SendWelcomeNotificationStepOutputModel 
    {
        public bool IsSent { get; set; }
    }
}
