using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wfc.Domains;
using Wfc.Domains.Workflows.Registrations;
using Wfc.Providers.LocalProviders;
using WfcExample.Core;
using WfcExample.Core.Domains;
using WfcExample.Core.Services.Notifications;
using WfcExample.Core.Services.Registrations;
using WfcExample.Core.Services.ThirdPartyServices;
using WorkflowCore.Models;
using WorkflowCore.Testing;

namespace WfcExample.Tests.IntegrationTests
{
    [TestFixture]
    public class RegistrationFlowTest : WorkflowTest<RegistrationWorkflow, RegistrationWorkflowModel>
    {
        private IServiceCollection services;

        [SetUp]
        protected override void Setup()
        {
            base.Setup();
        }

        protected override void ConfigureServices(IServiceCollection services)
        {
            services.AddWfc(config => 
            {
                config.AddLocalProviders();
                config.AddFlows();
            });

            this.services = services;

            base.ConfigureServices(services);
        }


        [Test]
        public void Registration_Should_Pass() 
        {
            // data
            var login = "some_name";
            var password = "some_password";

            var calculatedUserId = string.Empty;

            // setup
            var thirdPartyServicee = GetThrirdPartyService();

            var code = thirdPartyServicee.GenerateCode(login);

            // act
            var workflowId = StartWorkflow(new RegistrationWorkflowModelInit(login, password));

            WaitForEventSubscription(RegistrationEvents.UserCodeReceived, login, TimeSpan.FromSeconds(5));
            Host.PublishEvent(RegistrationEvents.UserCodeReceived, login, code);

            WaitForWorkflowToComplete(workflowId, TimeSpan.FromSeconds(5));

            // check
            var status = GetStatus(workflowId);
            var errors = UnhandledStepErrors.Count;
            var data = GetData(workflowId);

            Assert.That(status, Is.EqualTo(WorkflowStatus.Complete));
            Assert.That(errors, Is.EqualTo(0));
            Assert.That(data.SendWelcomeNotificationStepOutput.IsSent, Is.True);
        }

        private InMemoryThridPartyDataStoreProvider GetThrirdPartyService() 
        {
            var services = this.services.BuildServiceProvider();
            var thirdPartyServicee = (InMemoryThridPartyDataStoreProvider)services.GetService<IThirdPartyDataStoreProvider>();

            return thirdPartyServicee;
        }

    }
}
