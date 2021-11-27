using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SalesWebApi.Models;

namespace SalesWebApi.Repository
{
    public interface ILoginRepository
    {
        public Login GetUser(string userName, string password);

        Login GetUserByPassword(string un, string pwd);
    }
}
