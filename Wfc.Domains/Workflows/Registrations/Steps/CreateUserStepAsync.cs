using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WfcExample.Core.Domains;
using WfcExample.Core.Services.Registrations;
using WorkflowCore.Interface;
using WorkflowCore.Models;

namespace Wfc.Domains.Workflows.Registrations.Steps
{
    public class CreateUserStepAsync : StepBodyAsync
    {
        public CreateUserStepInputModel Input { get; set; } = new CreateUserStepInputModel();

        public CreateUserStepOutputModel Output { get; set; } = new CreateUserStepOutputModel();

        private readonly IUsersDataStore store;

        public CreateUserStepAsync(IUsersDataStore store)
        {
            this.store = store; 
        }

        public override async Task<ExecutionResult> RunAsync(IStepExecutionContext context)
        {
            var user = new User() 
            {
                IsRegistered = false,
                Login = this.Input.Login,
                Password = this.Input.Password
            };

            var userId = await this.store.CreateUserAsync(user);

            this.Output.UserId = userId;

            return ExecutionResult.Next();
        }
    }

    public class CreateUserStepInputModel 
    {
        public string Login { get; set; }

        public string Password { get; set; }
    }

    public class CreateUserStepOutputModel 
    {
        public string UserId { get; set; }
    }
}
