using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WfcExample.Core.Domains;
using WfcExample.Core.Services.Registrations;
using WorkflowCore.Interface;

namespace Wfc.Domains.Workflows.Registrations
{
    public class RegistrationService : IRegistrationService
    {
        private IWorkflowController workflowService;

        public RegistrationService(IWorkflowController workflowService)
        {
            this.workflowService = workflowService;
        }

        public async Task<string> SendUserCodeAsync(string login, string code)
        {
            await this.workflowService.PublishEvent(RegistrationEvents.UserCodeReceived, login, code);

            return code;
        }

        public async Task<string> StarRegistrationFlowAsync(string login, string password)
        {
            var data = new RegistrationWorkflowModelInit(login, password);

            var result = await this.workflowService
                .StartWorkflow(RegistrationWorkflow.WorkflowId, data);

            return result;
        }
    }
}
