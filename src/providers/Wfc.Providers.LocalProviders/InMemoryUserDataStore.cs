using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WfcExample.Core.Domains;
using WfcExample.Core.Services.Registrations;

namespace Wfc.Providers.LocalProviders
{
    internal class InMemoryUserDataStore : IUsersDataStore
    {
        private readonly Dictionary<string, User> store = new Dictionary<string, User>();

        public Task<string> CreateUserAsync(User user)
        {
            store.Add(user.Login, user);

            return Task.FromResult(user.Login);
        }

        public Task<User> GetUserAsync(string id)
        {
            return Task.FromResult(store[id]);
        }

        public Task<User[]> GetUsersAsync()
        {
            var users = store.Select(x => x.Value).ToArray();

            return Task.FromResult(users);
        }

        public Task UpdateUserAsync(string id, User newValue)
        {
            this.store[id] = newValue;

            return Task.CompletedTask;
        }
    }
}
