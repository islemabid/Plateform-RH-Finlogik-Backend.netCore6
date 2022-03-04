using Microsoft.AspNetCore.Builder;

namespace Plateform_RH_Finlogik.Api.Middleware
{
    public static class MiddlewareExtensions
    {
        //ma3neha n9oul il IApplicationBuilder a3tini il access lil middleware pipeline
        public static IApplicationBuilder UseCustomExceptionHandler(this IApplicationBuilder builder)
        {
            //using the  UseMiddleware passing  in ExceptionHandlerMiddleware , this extension method n3aytelha fil porgram.cs
            return builder.UseMiddleware<ExceptionHandlerMiddleware>();
        }
    }
}
