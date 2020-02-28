using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TokenMiddlewareAndMapping.MiddlewareSource
{
    public class TokenMiddleware_v2
    {
        private RequestDelegate _next;
        private string _pattern;
        public TokenMiddleware_v2(RequestDelegate next, string pattern)
        {
            _next = next;
            _pattern = pattern;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            var token = context.Request.Query["token"];
            if (token != _pattern)
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

    public static class TokenExtension2
    {
        public static IApplicationBuilder UseToken2(this IApplicationBuilder applicationBuilder)
        {
            return applicationBuilder.UseMiddleware<TokenMiddleware_v2>();
        }
    }
}
