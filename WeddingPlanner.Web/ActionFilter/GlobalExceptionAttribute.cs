﻿using System;
using System.ComponentModel.DataAnnotations;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Filters;
using System.Web.Http.Tracing;
using WeddingPlanner.Web.Helpers;
namespace WeddingPlanner.Web.ActionFilter
{
        /// <summary>
        /// Action filter to handle for Global application errors.
        /// </summary>
        public class GlobalExceptionAttribute : ExceptionFilterAttribute
        {
            public override void OnException(HttpActionExecutedContext context)
            {
                GlobalConfiguration.Configuration.Services.Replace(typeof(ITraceWriter), new NLogger());
                var trace = GlobalConfiguration.Configuration.Services.GetTraceWriter();
                trace.Error(
                    context.Request,
                    "Controller : " + context.ActionContext.ControllerContext.ControllerDescriptor.ControllerType.FullName + Environment.NewLine + "Action : " + context.ActionContext.ActionDescriptor.ActionName,
                    context.Exception
                );

                var exceptionType = context.Exception.GetType();
                var exception = context.Exception as IApiExceptions;

                if (exceptionType == typeof(ValidationException))
                {
                    var resp = new HttpResponseMessage(HttpStatusCode.BadRequest) { Content = new StringContent(context.Exception.Message), ReasonPhrase = "ValidationException", };
                    throw new HttpResponseException(resp);
                }
                else if (exception is IApiExceptions)
                {
                    throw new HttpResponseException(context.Request.CreateResponse(
                        exception.HttpStatus,
                        new ServiceStatus() { StatusCode = exception.ErrorCode, StatusMessage = exception.ErrorDescription, ReasonPhrase = exception.ReasonPhrase })
                    );
                }
                else
                {
                    throw new HttpResponseException(context.Request.CreateResponse(HttpStatusCode.InternalServerError));
                }
            }
        }
    
}