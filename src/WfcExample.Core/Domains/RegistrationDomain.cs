using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WfcExample.Core.Services.Registrations;

namespace WfcExample.Core.Domains
{
    public class RegistrationDomain
    {
        private readonly IRegistrationService service;

        public RegistrationDomain(IRegistrationService service)
        {
            this.service = service;
        }

        public async Task<string> CreateUser(string login, string password)
        {
            var processId = await this.service.StarRegistrationFlowAsync(login, password);

            return processId;
        }

        public async Task<string> SendCode(string login, string code) 
        {
            var processId = await this.service.SendUserCodeAsync(login, code);

            return processId;
        }
    }
}
