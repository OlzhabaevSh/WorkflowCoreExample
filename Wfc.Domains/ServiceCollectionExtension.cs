using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wfc.Domains.Workflows.Registrations;
using Wfc.Domains.Workflows.Registrations.Steps;
using WfcExample.Core;
using WfcExample.Core.Services.Registrations;
using WfcExample.Core.Services.ThirdPartyServices;

namespace Wfc.Domains
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddFlows(this WfcConfig config, bool addWorkflow = false) 
        {
            //config.Services.AddWorkflow();
            AddSteps(config.Services);

            if (addWorkflow) 
            {
                config.Services.AddWorkflow();
            }

            config.Services.AddTransient<IRegistrationService, RegistrationService>();
            config.Services.AddTransient<ThirdPartyService>();

            return config.Services;
        }

        private static IServiceCollection AddSteps(IServiceCollection services) 
        {
            services.AddSingleton<CreateUserStepAsync>();
            services.AddSingleton<FinishRegistrationStepAsync>();
            services.AddSingleton<GenerateThirdPartyCodeStepAsync>();
            services.AddSingleton<HandleThirdPartyCodeStepAsync>();
            services.AddSingleton<SendUserCodeStepAsync>();
            services.AddSingleton<SendWelcomeNotificationStepAsync>();

            return services;
        }

    }
}
