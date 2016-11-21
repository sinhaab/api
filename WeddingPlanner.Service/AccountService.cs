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
               return db.USP_Account_Insert(email, password, name, brideName, groomName, weddingDate, weddingTime).ToList();
           }
        }

       public IEnumerable<string> VerifyAccount(string email, string password)
       {
           using (var db = _dbContext.GetDbContext())
           {
               return db.USP_Account_Verification(email, password).ToList();
           }
       }
       public IEnumerable<string> ChangePassword(string email, string oldPassword,string newPassword, string name)
       {
           using (var db = _dbContext.GetDbContext())
           {
               return db.USP_Account_ChangePassword(email, oldPassword, newPassword,name).ToList();
           }
       }

       public IEnumerable<WeddingCountdownEntity> WeddingCountDown(string email)
       {
           using (var db = _dbContext.GetDbContext())
           {
               var accountDetail = db.USP_WeddingCountdown_Select(email).ToList();
               if (accountDetail != null)
               {
                   IEnumerable<WeddingCountdownEntity> weddingCountdown =
                                             from p in accountDetail
                                             select new WeddingCountdownEntity
                                                  {                                     
                                                    BrideName = p.BrideName, 
                                                    GroomName =p.GroomName,
                                                    WeddingDate=p.WeddingDate,
                                                    WeddingTime = p.WeddingTime.ToString()
                                                    
                                                    //+ (System.TimeSpan.FromMinutes(p.WeddingTime))
                                                  };
                         return weddingCountdown.ToList();
               }
               return null;


            
           }

       }
    }
}
