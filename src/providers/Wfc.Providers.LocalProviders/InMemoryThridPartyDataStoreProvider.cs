using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WfcExample.Core.Services.ThirdPartyServices;

namespace Wfc.Providers.LocalProviders
{
    public class InMemoryThridPartyDataStoreProvider : IThirdPartyDataStoreProvider
    {
        private Dictionary<string, string> codes = new Dictionary<string, string>();

        public string CreateCode(string user)
        {
            if (codes.ContainsKey(user))
                return codes[user];

            var code = GenerateCode(user);

            codes.Add(user, code);

            return code;
        }

        public string GetCode(string user)
        {
            if (codes.ContainsKey(user))
                return codes[user];
            else
                return string.Empty;
        }

        public void DeleteCode(string user)
        {
            codes.Remove(user);
        }

        public void Clear()
        {
            codes.Clear();
        }

        public string GenerateCode(string user)
        {
            return $"$_{user}_$";
        }
    }
}
