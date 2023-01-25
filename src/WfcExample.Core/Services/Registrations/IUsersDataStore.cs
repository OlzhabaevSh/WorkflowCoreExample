using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WfcExample.Core.Domains;

namespace WfcExample.Core.Services.Registrations
{
    public interface IUsersDataStore
    {
        Task<User[]> GetUsersAsync();

        Task<User> GetUserAsync(string id);

        Task<string> CreateUserAsync(User user);

        Task UpdateUserAsync(string id, User newValue);
    }
}
