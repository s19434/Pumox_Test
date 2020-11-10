using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pumox_Test.Services.Authentication
{
    public class SqlServerUserDbService : IUserDbService
    {
        private readonly List<Logged_User> usersList = new List<Logged_User>();

        public async Task<Logged_User> Authentication(string username, string password)
        {
            var user = await Task.Run(() =>
            {
                return usersList.SingleOrDefault(x =>
                {
                    return x.UserName == username && x.Password == password;
                });

            }).ConfigureAwait(false);
            if (user == null)
                return null;
            user.Password = null;
            return user;
        }

        public async Task<IEnumerable<Logged_User>> GetAll()
        {
            return await Task.Run(() =>
            {
                return usersList.Select(x =>
                {
                    x.Password = null; return x;
                });
            });
        }
    }
}
