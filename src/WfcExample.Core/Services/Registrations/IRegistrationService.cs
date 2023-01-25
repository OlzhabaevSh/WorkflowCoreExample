using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WfcExample.Core.Services.Registrations
{
    public interface IRegistrationService
    {
        Task<string> StarRegistrationFlowAsync(string login, string password);

        Task<string> SendUserCodeAsync(string userId, string code);
    }
}
