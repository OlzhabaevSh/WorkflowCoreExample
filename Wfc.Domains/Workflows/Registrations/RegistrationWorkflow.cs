using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wfc.Domains.Workflows.Registrations.Steps;
using WfcExample.Core.Domains;
using WorkflowCore.Interface;

namespace Wfc.Domains.Workflows.Registrations
{
    public class RegistrationWorkflow : IWorkflow<RegistrationWorkflowModel>
    {
        public static string WorkflowId => typeof(RegistrationWorkflow).Name;

        public string Id => WorkflowId;

        public int Version => 1;

        public void Build(IWorkflowBuilder<RegistrationWorkflowModel> builder)
        {
            builder
                .StartWith<CreateUserStepAsync>()
                    .Input(step => step.Input.Login, data => data.CreateUserStepInput.Login)
                    .Input(step => step.Input.Password, data => data.CreateUserStepInput.Password)
                    .Output(data => data.CreateUserStepOutput, step => step.Output)                    
                .Then<GenerateThirdPartyCodeStepAsync>()
                    .Input(step => step.Input.UserName, data => data.CreateUserStepInput.Login)
                    .Output(data => data.GenerateThirdPartyCodeStepOutput, step => step.Output)
                .Then<SendUserCodeStepAsync>()
                    .Input(step => step.Input.UserName, data => data.CreateUserStepInput.Login)
                    .Input(step => step.Input.Code, data => data.GenerateThirdPartyCodeStepOutput.SystemGeneratedCode)
                .WaitFor(RegistrationEvents.UserCodeReceived, 
                        data => data.CreateUserStepInput.Login)
                    .Output(data => data.HandleThirdPartyCodeStepInput.UserProvidedCode, step => step.EventData)
                .Then<HandleThirdPartyCodeStepAsync>()
                    .Input(step => step.Input.SystemGeneratedCode, data => data.GenerateThirdPartyCodeStepOutput.SystemGeneratedCode)
                    .Input(step => step.Input.UserName, data => data.CreateUserStepInput.Login)
                    .Input(step => step.Input.UserProvidedCode, data => data.HandleThirdPartyCodeStepInput.UserProvidedCode)
                .Then<FinishRegistrationStepAsync>()
                    .Input(step => step.Input.UserName, data => data.CreateUserStepInput.Login)
                .Then<SendWelcomeNotificationStepAsync>()
                    .Input(step => step.Input.UserName, data => data.CreateUserStepInput.Login)
                    .Output(data => data.SendWelcomeNotificationStepOutput, step => step.Output);
        }
    }
}
