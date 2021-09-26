using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace cwiczenia8.Middlewares
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
            catch (Exception e)
            {
                HandleException(httpContext, e);
            }
        }

        private void HandleException(HttpContext httpContext, Exception exception)
        {
            using ( StreamWriter writer = new StreamWriter( "logs.txt", true ) )
            {
                while ( exception != null )
                {
                    writer.WriteLine( exception.GetType().FullName );
                    writer.WriteLine( "Message : " + exception.Message );
                    writer.WriteLine( "StackTrace : " + exception.StackTrace );

                    exception = exception.InnerException;
                }
            }
        }
    }
}
