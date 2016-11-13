#region Using namespaces.
using System;
using System.Net;
using System.Runtime.Serialization;
#endregion

namespace WeddingPlanner.Web.Helpers
{
    /// <summary>
    /// Api Data Exception
    /// </summary>
    public class ApiDataException : Exception, IApiExceptions
    {
        #region Public Serializable properties.
        
        public int ErrorCode { get; set; }        
        public string ErrorDescription { get; set; }        
        public HttpStatusCode HttpStatus { get; set; }

        private string reasonPhrase = "ApiDataException";        
        public string ReasonPhrase
        {
            get { return this.reasonPhrase; }
            set { this.reasonPhrase = value; }
        }

        #endregion

        #region Public Constructor.
        /// <summary>
        /// Public constructor for Api Data Exception
        /// </summary>
        /// <param name="errorCode"></param>
        /// <param name="errorDescription"></param>
        /// <param name="httpStatus"></param>
        public ApiDataException(int errorCode, string errorDescription, HttpStatusCode httpStatus)
        {
            ErrorCode = errorCode;
            ErrorDescription = errorDescription;
            HttpStatus = httpStatus;
        }
        #endregion
    }
}