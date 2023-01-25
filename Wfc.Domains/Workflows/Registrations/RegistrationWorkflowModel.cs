using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wfc.Domains.Workflows.Registrations.Steps;

namespace Wfc.Domains.Workflows.Registrations
{
    public class RegistrationWorkflowModel
    {
        public CreateUserStepInputModel CreateUserStepInput { get; set; }

        public CreateUserStepOutputModel CreateUserStepOutput { get; set; }


        public GenerateThirdPartyCodeStepInputModel GenerateThirdPartyCodeStepInput { get; set; }

        public GenerateThirdPartyCodeStepOutputModel GenerateThirdPartyCodeStepOutput { get; set; }


        public HandleThirdPartyCodeStepOutputModel HandleThirdPartyCodeStepOutput { get; set; }

        public HandleThirdPartyCodeStepInputModel HandleThirdPartyCodeStepInput { get; set; }


        public FinishRegistrationStepInputModel FinishRegistrationStepInput { get; set; }

        public FinishRegistrationStepOutputModel FinishRegistrationStepOutput { get; set; }


        public SendWelcomeNotificationStepInputModel SendWelcomeNotificationStepInput { get; set; }

        public SendWelcomeNotificationStepOutputModel SendWelcomeNotificationStepOutput { get; set; }
    }

    public class RegistrationWorkflowModelInit : RegistrationWorkflowModel
    {
        public RegistrationWorkflowModelInit(string login, string password)
        {
            this.CreateUserStepInput = new CreateUserStepInputModel() 
            {
                Login= login,
                Password = password
            };
            this.CreateUserStepOutput = new CreateUserStepOutputModel();

            this.GenerateThirdPartyCodeStepOutput = new GenerateThirdPartyCodeStepOutputModel();
            this.GenerateThirdPartyCodeStepInput = new GenerateThirdPartyCodeStepInputModel();

            this.HandleThirdPartyCodeStepOutput = new HandleThirdPartyCodeStepOutputModel();
            this.HandleThirdPartyCodeStepInput = new HandleThirdPartyCodeStepInputModel();

            this.FinishRegistrationStepInput = new FinishRegistrationStepInputModel();
            this.FinishRegistrationStepOutput = new FinishRegistrationStepOutputModel();

            this.SendWelcomeNotificationStepInput = new SendWelcomeNotificationStepInputModel();
            this.SendWelcomeNotificationStepOutput = new SendWelcomeNotificationStepOutputModel();
        }
    } 
}
