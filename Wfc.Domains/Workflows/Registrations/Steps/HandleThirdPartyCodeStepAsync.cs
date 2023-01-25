using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WfcExample.Core.Services.ThirdPartyServices;
using WorkflowCore.Interface;
using WorkflowCore.Models;

namespace Wfc.Domains.Workflows.Registrations.Steps
{
    public class HandleThirdPartyCodeStepAsync : StepBodyAsync
    {
        public HandleThirdPartyCodeStepInputModel Input { get; set; } = new HandleThirdPartyCodeStepInputModel();

        public HandleThirdPartyCodeStepOutputModel Output { get; set; } = new HandleThirdPartyCodeStepOutputModel();

        private readonly ThirdPartyService service;

        public HandleThirdPartyCodeStepAsync(ThirdPartyService service)
        {
            this.service = service;
        }

        public override async Task<ExecutionResult> RunAsync(IStepExecutionContext context)
        {
            var verifyResult = await this.service.VerifyCodeAsync(this.Input.UserName, this.Input.UserProvidedCode);

            if (!verifyResult) 
            {
                throw new Exception("Code is not valid");
            }

            return ExecutionResult.Next();
        }
    }

    public class HandleThirdPartyCodeStepInputModel 
    {
        public string UserProvidedCode { get; set; }

        public string SystemGeneratedCode { get; set; }

        public string UserName { get; set; }
    }

    public class HandleThirdPartyCodeStepOutputModel 
    {
    }
}
