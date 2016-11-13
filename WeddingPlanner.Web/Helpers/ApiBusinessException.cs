#region Using namespaces.
using System;
using System.Net;
using System.Runtime.Serialization; 
#endregion

namespace WeddingPlanner.Web.Helpers
{
    /// <summary>
    /// Api Business Exception
    /// </summary>   
    public class ApiBusinessException : Exception, IApiExceptions
    {
        #region Public Serializable properties.
        
        public int ErrorCode { get; set; }        
        public string ErrorDescription { get; set; }        
        public HttpStatusCode HttpStatus { get; set; }

        private string reasonPhrase = "ApiBusinessException";        
        public string ReasonPhrase
        {
            get { return this.reasonPhrase; }
            set { this.reasonPhrase = value; }
        }
        #endregion

        #region Public Constructor.
        /// <summary>
        /// Public constructor for Api Business Exception
        /// </summary>
        /// <param name="errorCode"></param>
        /// <param name="errorDescription"></param>
        /// <param name="httpStatus"></param>
        public ApiBusinessException(int errorCode, string errorDescription, HttpStatusCode httpStatus)
        {
            ErrorCode = errorCode;
            ErrorDescription = errorDescription;
            HttpStatus = httpStatus;
        } 
        #endregion

    }
}