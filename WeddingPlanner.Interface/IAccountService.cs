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
        IEnumerable<string> InsertSignUpAccount(string Email, string Password, string Name, string BrideName, string GroomName, DateTime WeddingDate, TimeSpan WeddingTime);
        IEnumerable<string> VerifyAccount(string Email, string Password);
        IEnumerable<string> ChangePassword(string Email, string Password,string Name);
    }
}
