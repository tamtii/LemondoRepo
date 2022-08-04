using Microsoft.AspNetCore.Http;
using Statements.Contracts.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Statements.Contracts.CustomExceptionMiddleware
{
  public class ExceptionMiddleware
  {
    private readonly RequestDelegate _next;
    public ExceptionMiddleware(RequestDelegate next)
    {
      _next = next;
    }
    public async Task InvokeAsync(HttpContext httpContext)
    {
      try
      {
        await _next(httpContext);
      }
      catch(Exception ex)
      {
        await HandleExceptionAsync(httpContext,ex);
      }
    }
    private Task HandleExceptionAsync(HttpContext context, Exception ex)
    {
      context.Response.ContentType = @"application\json";
      context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
      return context.Response.WriteAsync(new ErrorDetails
      {
        StatusCode=context.Response.StatusCode,
        Message=ex.Message
      }.ToString());
    }
  }
}
