using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WfcExample.Core.Domains;
using WfcExample.Core.Services.Notifications;

namespace WfcExample.Core
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddWfc(
            this IServiceCollection services,
            Action<WfcConfig> configDelegate) 
        {
            // register
            services.AddTransient<RegistrationDomain>();
            services.AddTransient<NotificationService>();

            // tales

            var config = new WfcConfig() 
            {
                Services = services,
            };

            configDelegate(config);

            return services;
        }
    }

    public class WfcConfig 
    {
        public IServiceCollection Services { get; set; }
    }

}
