using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeddingPlanner.Entities;
using WeddingPlanner.Interface;
using WeddingPlanner.Data;
using System.Data.Entity;
using WeddingPlanner.Data.Interface;

namespace WeddingPlanner.Service
{
    public class AccountService : IAccountService
    {
       private readonly IDbContextFactory _dbContext;

       public AccountService(IDbContextFactory dbContextFactory)
       {
        _dbContext = dbContextFactory;
       }

       public  IEnumerable<string> InsertSignUpAccount(string email, string password, string name, string brideName, string groomName, DateTime weddingDate, TimeSpan weddingTime)
       {
           using (var db = _dbContext.GetDbContext())
           {             
               return db.USP_Account_Insert(email, password, name, brideName, groomName, weddingDate, weddingTime).AsEnumerable();
           }
        }

       public IEnumerable<string> VerifyAccount(string email, string password)
       {
           using (var db = _dbContext.GetDbContext())
           {
               return db.USP_Account_Verification(email, password).AsEnumerable();
           }
       }
       public IEnumerable<string> ChangePassword(string email, string password, string name)
       {
           using (var db = _dbContext.GetDbContext())
           {
               return db.USP_Account_ChangePassword(email, password, name).AsEnumerable();
           }
       }
    }
}
