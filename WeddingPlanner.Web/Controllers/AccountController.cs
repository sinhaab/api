using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WeddingPlanner.Service;
using WeddingPlanner.Interface;
using System.Globalization;
using WeddingPlanner.Entities;

namespace WeddingPlanner.Web.Controllers
{
    public class AccountController : ApiController
    {
        #region Vairiables
        private readonly IAccountService _accountService=null;
        #endregion

        #region Constructor
        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }
        #endregion
        

        [HttpGet]
        public HttpResponseMessage SignUp(string email, string password, string name, string brideName, string groomName, string weddingDate, string weddingTime)
        {
           TimeSpan time;
           time = DateTime.ParseExact(weddingTime, "hh:mm tt", CultureInfo.InvariantCulture).TimeOfDay;
           DateTime dtWedding;
           string[] sDate = weddingDate.Split('/');
           string sDateTime = sDate[1] + '/' + sDate[0] + '/' + sDate[2];
           dtWedding = Convert.ToDateTime(sDateTime);          
           IEnumerable<string> result = _accountService.InsertSignUpAccount(email, password, name, brideName, groomName, dtWedding, time);
           HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, result);
           return response;
        }
        [HttpGet]
        public HttpResponseMessage VerifyAccount(string email, string password)
        {
            IEnumerable<string> result = _accountService.VerifyAccount(email, password);
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, result);
            return response;
        }
        [HttpGet]
        public HttpResponseMessage ChangePassword(string email, string oldpassword, string newpassword, string name)
        {
            IEnumerable<string> result = _accountService.ChangePassword(email, oldpassword, newpassword, name);
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, result);
            return response;
        }

        [HttpGet]
        public HttpResponseMessage WeddingCountdown(string email)
        {
            var result = _accountService.WeddingCountDown(email);
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, result.ToList());
            return response;
        }

        [HttpGet]
        public HttpResponseMessage UpdateWeddingCountdown(string email, string brideName, string groomName, string weddingDate, string weddingTime)
        {
            TimeSpan time;
            time = DateTime.ParseExact(weddingTime, "hh:mm tt", CultureInfo.InvariantCulture).TimeOfDay;
            DateTime dtWedding;
            string[] sDate = weddingDate.Split('/');
            string sDateTime = sDate[1] + '/' + sDate[0] + '/' + sDate[2];
            dtWedding = Convert.ToDateTime(sDateTime);
            var result = _accountService.UpdateWeddingCountdown(email, brideName, groomName, dtWedding, time);
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, result);
            return response;
        }


         [HttpGet]
        public string Test()
        {
            return "Hello";
        }
    }
}