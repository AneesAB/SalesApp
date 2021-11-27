using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SalesWebApi.Models;

namespace SalesWebApi.Repository
{
    public class LoginRepository: ILoginRepository
    {
        SMSContext db;

        public LoginRepository(SMSContext _db)
        {
            db = _db;
        }


        //Login 
        #region login
        public Login GetUser(string userName, string password)
        {
            if (db != null)
            {
                Login log = db.Login.FirstOrDefault(lo => lo.Username == userName && lo.Password == password);
                if (log != null)
                {
                    return log;
                }
            }
            return null;
        }
        #endregion

        //login by password in url
        #region get user by password

        public Login GetUserByPassword(string un, string pwd)
        {
            if (db != null)
            {
                Login cred = db.Login.FirstOrDefault(log => log.Username == un && log.Password == pwd);
                if (cred != null)
                {
                    return cred;
                }
            }
            return null;
        }
        #endregion
    }
}
