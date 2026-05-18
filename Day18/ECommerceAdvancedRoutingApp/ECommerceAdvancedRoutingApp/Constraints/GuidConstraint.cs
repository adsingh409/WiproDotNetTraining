
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
namespace ECommerceAdvancedRoutingApp.Constraints
{


    public class GuidConstraint : IRouteConstraint
    {
        public bool Match(HttpContext httpContext, IRouter route,
            string routeKey, RouteValueDictionary values,
            RouteDirection routeDirection)
        {
            return Guid.TryParse(values[routeKey]?.ToString(), out _);
        }
    }
}