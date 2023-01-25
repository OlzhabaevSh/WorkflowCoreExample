using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WfcExample.Core.Services.ThirdPartyServices
{
    public interface IThirdPartyDataStoreProvider
    {
        public string CreateCode(string user);

        public string GetCode(string user);

        public void DeleteCode(string user);

        public void Clear();

        public string GenerateCode(string user);
    }
}
