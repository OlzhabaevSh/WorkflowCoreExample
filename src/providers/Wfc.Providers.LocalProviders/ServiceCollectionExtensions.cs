using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WfcExample.Core;
using WfcExample.Core.Services.Notifications;
using WfcExample.Core.Services.Registrations;
using WfcExample.Core.Services.ThirdPartyServices;

namespace Wfc.Providers.LocalProviders
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddLocalProviders(this WfcConfig config) 
        {
            config.Services.AddSingleton<INotificationProvider, ConsoleNotificatonProvider>();
            config.Services.AddSingleton<IThirdPartyDataStoreProvider, InMemoryThridPartyDataStoreProvider>();
            config.Services.AddSingleton<IUsersDataStore, InMemoryUserDataStore>();

            return config.Services;
        }
    }
}
