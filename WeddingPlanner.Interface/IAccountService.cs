using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeddingPlanner.Entities;

namespace WeddingPlanner.Interface
{
    public interface IAccountService
    {
       
        IEnumerable<string> InsertSignUpAccount(string email, string password, string name, string brideName, string groomName, DateTime weddingDate, TimeSpan weddingTime);
        IEnumerable<string> VerifyAccount(string email, string password);
        IEnumerable<string> ChangePassword(string email, string oldPassword,string newPassword,string name);
        IEnumerable<WeddingCountdownEntity> WeddingCountDown(string email);
    }
}
