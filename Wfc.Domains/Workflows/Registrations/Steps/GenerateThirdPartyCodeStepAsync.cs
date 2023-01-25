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
    public class GenerateThirdPartyCodeStepAsync : StepBodyAsync
    {
        public GenerateThirdPartyCodeStepInputModel Input { get; set; } = new GenerateThirdPartyCodeStepInputModel();

        public GenerateThirdPartyCodeStepOutputModel Output { get; set; } = new GenerateThirdPartyCodeStepOutputModel();

        private ThirdPartyService service;

        public GenerateThirdPartyCodeStepAsync(ThirdPartyService service)
        {
            this.service = service;
        }

        public override async Task<ExecutionResult> RunAsync(IStepExecutionContext context)
        {
            var code = await this.service.GenerateCodeAsync(this.Input.UserName);

            this.Output.SystemGeneratedCode = $"__{code}";

            return ExecutionResult.Next();
        }
    }

    public class GenerateThirdPartyCodeStepInputModel 
    {
        public string UserName { get; set; }
    }

    public class GenerateThirdPartyCodeStepOutputModel 
    {
        public string SystemGeneratedCode { get; set; }
    }
}
