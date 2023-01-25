using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WfcExample.Core.Services.ThirdPartyServices
{
    public class ThirdPartyService
    {
        private readonly IThirdPartyDataStoreProvider store;

        public ThirdPartyService(IThirdPartyDataStoreProvider store)
        {
            this.store = store;
        }

        public Task<string> GenerateCodeAsync(string user) 
        {
            var code = this.store.CreateCode(user);

            return Task.FromResult(code);
        }

        public Task<bool> VerifyCodeAsync(string user, string code) 
        {
            var storedCode = this.store.GetCode(user);

            var result = !string.IsNullOrEmpty(storedCode) && storedCode == code;

            return Task.FromResult(result);
        }
    }
}
