using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WfcExample.Core.Services.Notifications;
using WfcExample.Core.Services.ThirdPartyServices;
using WorkflowCore.Interface;
using WorkflowCore.Models;

namespace Wfc.Domains.Workflows.Registrations.Steps
{
    public class SendUserCodeStepAsync : StepBodyAsync
    {
        public SendUserCodeSendInputModel Input { get; set; } = new SendUserCodeSendInputModel();

        public SendUserCodeSendOutputModel Output { get; set; } = new SendUserCodeSendOutputModel();

        private readonly NotificationService service;

        public SendUserCodeStepAsync(NotificationService service)
        {
            this.service = service;
        }

        public override async Task<ExecutionResult> RunAsync(IStepExecutionContext context)
        {
            await this.service.SendCode(this.Input.UserName, this.Input.Code);

            return ExecutionResult.Next();
        }
    }

    public class SendUserCodeSendInputModel 
    {
        public string UserName { get; set; }

        public string Code { get; set; }
    }

    public class SendUserCodeSendOutputModel 
    {
    }

}
