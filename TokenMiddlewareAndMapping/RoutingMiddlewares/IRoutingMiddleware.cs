using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TokenMiddlewareAndMapping.RoutingMiddlewares
{
    public interface IRoutingMiddleware
    {
        public interface IRoutingMiddleware
        {
            Task InvaokeAsync(HttpContext httpContext);
        }
    }
}
