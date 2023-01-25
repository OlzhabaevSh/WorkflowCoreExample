using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WfcExample.Core.Services.Registrations;
using WorkflowCore.Interface;
using WorkflowCore.Models;

namespace Wfc.Domains.Workflows.Registrations.Steps
{
    public class FinishRegistrationStepAsync : StepBodyAsync
    {
        public FinishRegistrationStepInputModel Input { get; set; } = new FinishRegistrationStepInputModel();   

        public FinishRegistrationStepOutputModel Output { get; set; } = new FinishRegistrationStepOutputModel();    

        private readonly IUsersDataStore store;

        public FinishRegistrationStepAsync(IUsersDataStore store)
        {
            this.store = store;
        }

        public override async Task<ExecutionResult> RunAsync(IStepExecutionContext context)
        {
            var data = await this.store.GetUserAsync(this.Input.UserName);

            data.IsRegistered = true;

            await this.store.UpdateUserAsync(this.Input.UserName, data);

            return ExecutionResult.Next();
        }
    }

    public class FinishRegistrationStepInputModel 
    {
        public string UserName { get; set; }
    }

    public class FinishRegistrationStepOutputModel 
    {
    }
}
