using System.Collections.Generic;
using System.Threading.Tasks;

namespace Pumox_Test.Services.Authentication
{
    public interface IUserDbService
    {
        Task<Logged_User> Authentication(string username, string password);

        Task<IEnumerable<Logged_User>> GetAll();
    }
}
