using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TokenMiddlewareAndMapping.RoutingMiddlewares
{
    public class RoutingMiddleware
    {

        private RequestDelegate _next;
        public RoutingMiddleware(RequestDelegate next)
        {
            _next = next;
        }
        //http://localhost:4585/index?token=12345
        //Domen - localhost
        //Port-4585
        //Path- index
        //Request Parametr token=123

        public Task Invoke(HttpContext _httpContext)
        {
            var path = _httpContext.Request.Path.Value;
            if (path == "/")
            {
                _httpContext.Request.Path = "/Home/index";
            }
            return _next(_httpContext);
        }
    }

}
