#region Using namespaces.
using System;
using System.Net;
using System.Runtime.Serialization;
#endregion


namespace WeddingPlanner.Web.Helpers
{
    /// <summary>
    /// Api Exception
    /// </summary>    
    public class ApiException : Exception, IApiExceptions
    {                
        public int ErrorCode { get; set; }        
        public string ErrorDescription { get; set; }        
        public HttpStatusCode HttpStatus { get; set; }
        
        private string reasonPhrase = "ApiException";        
        public string ReasonPhrase
        {
            get { return this.reasonPhrase; }

            set { this.reasonPhrase = value; }
        }        
    }
}