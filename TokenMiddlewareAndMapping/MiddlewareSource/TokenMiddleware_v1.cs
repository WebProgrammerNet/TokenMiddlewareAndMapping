using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TokenMiddlewareAndMapping.MiddlewareSource
{
    public class TokenMiddleware_v1
    {
        private RequestDelegate _next;
        public TokenMiddleware_v1(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            var token = context.Request.Query["token"];
            if (token != "123456")
            {
                context.Response.StatusCode = 403;
                await context.Response.WriteAsync("Token is invalid");
            }
            else
            {
                await _next(context);
            }
        }

    }

    public static class TokenExtension
    {
        public static IApplicationBuilder UseToken(this IApplicationBuilder applicationBuilder)
        {
            return applicationBuilder.UseMiddleware<TokenMiddleware_v1>();
        }
    }
}
